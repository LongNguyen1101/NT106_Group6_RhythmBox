using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RhythmBox
{
    internal class ApiService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "https://rhythmboxserver.azurewebsites.net/api";

        public ApiService()
        {
            httpClient = new HttpClient();
        }

        public ApiService(string token)
        {
            httpClient = new HttpClient();
            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // Account //
        public async Task<bool> Account_SignIn(string username, string password)
        {
            var user = new
            {
                email = username,
                password = password
            };
            var userJson = JsonConvert.SerializeObject(user);

            var content = new StringContent(userJson, Encoding.UTF8, "application/json");

            //string requestUrl = $"{BaseUrl}/Account/login?email={username}&password={password}";

            //var response = await httpClient.PostAsync(requestUrl, null);
            var response = await httpClient.PostAsync($"{BaseUrl}/account/login", content);

            var responseJson = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TokenManager.SetAccessToken(responseJson);
                return true;
            }
            return false;
        }

        public async Task<bool> Account_SignUp(string username, string email, string password, DateTime birthday, string gender)
        {
            var user = new
            {
                username = username,
                email = email,
                password = password,
                birthday = birthday,
                gender = gender
            };

            var userJson = JsonConvert.SerializeObject(user);

            var content = new StringContent(userJson, Encoding.UTF8, "application/json");

            string requestUrl = $"{BaseUrl}/Account/register?userName={username}&email={email}&password={password}&birthday={birthday}&gender={gender}";

            //var response = await httpClient.PostAsync(requestUrl, null);
            var response = await httpClient.PostAsync($"{BaseUrl}/Account/register", content);

            var responseJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> updateAccount(string fullName, string bioData, string bioFileName, string imageData, string imageFileName)
        {
            try
            {
                var request = new
                {
                    fullName = fullName,
                    bioData = bioData,
                    bioFileName = bioFileName,
                    imageData = imageData,
                    imageFileName = imageFileName
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync($"{BaseUrl}/Account/updateAccount", content);

                var responseJson = response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // ForgotPassword //
        public async Task<bool> ForgotPassword(string email)
        {
            var request = new
            {
                email
            };
            var requestJson = JsonConvert.SerializeObject(request);

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            //string requestUrl = $"{BaseUrl}/Forgotpassword?email={email}";

            //var response = await httpClient.PostAsync(requestUrl, null);

            var response = await httpClient.PostAsync($"{BaseUrl}/ForgotPassword", content);

            var responseJson = response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return false;
            return true;
        }

        public async Task<bool> AuthOTP(string email, int enteredOtp)
        {
            try
            {
                var otpRequest = new
                {
                    email = email,
                    enteredOtp = enteredOtp
                };

                var otpRequestJson = JsonConvert.SerializeObject(otpRequest);

                var content = new StringContent(otpRequestJson, Encoding.UTF8, "application/json");

                //string requestUrl = $"{BaseUrl}/ForgotPassword/Authentication?email={email}&enteredOtp={enteredOtp.ToString()}";

                //var response = await httpClient.PostAsync(requestUrl, null);
                var response = await httpClient.PostAsync($"{BaseUrl}/Forgotpassword/Authentication", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> RenewPassword(string email, string newpass)
        {
            var request = new
            {
                email = email,
                newpass = newpass

            };
            var requestJson = JsonConvert.SerializeObject(request);

            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            //string requestUrl = $"{BaseUrl}/Forgotpassword/RenewPassword?email={email}&newPassword={newpass}";

            //var response = await httpClient.PostAsync(requestUrl, null);
            var response = await httpClient.PutAsync($"{BaseUrl}/Forgotpassword/RenewPassword", content);

            if (!response.IsSuccessStatusCode)
                return false;
            return true;
        }

        // AlbumArtist //
        public async Task<bool> AlbumArtist_createAlbum(int artistId, string title, DateTime releaseDate, byte[] image)
        {
            try
            {
                var request = new
                {
                    artistId = artistId,
                    title = title,
                    releaseDate = releaseDate,
                    image = image
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{BaseUrl}/AlbumsArtist/createAlbum", content);

                var responseJson = response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> AlbumArtist_addTrack(int albumId, int trackId)
        {
            try
            {
                var request = new
                {
                    albumId = albumId,
                    trackId = trackId
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{BaseUrl}/AlbumsArtist/addTrack", content);

                var responseJson = response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> AlbumArtist_deleteAlbum(int albumId)
        {
            try
            {
                string URLendpoint = $"{BaseUrl}/AlbumsArtist/deleteAlbum?albumId={albumId}";

                var response = await httpClient.DeleteAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> AlbumArtist_deleteTrack(int albumId, int trackId)
        {
            try
            {
                string URLendpoint = $"{BaseUrl}/AlbumsArtist/deleteTrack?albumId={albumId}&trackId={trackId}";

                var response = await httpClient.DeleteAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> AlbumArtist_updateInformation(int albumId, string title, DateTime releaseDate, byte[] image)
        {
            try
            {
                var request = new
                {
                    albumId = albumId,
                    title = title,
                    releaseDate = releaseDate,
                    image = image
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{BaseUrl}/AlbumsArtist/updateInformation", content);

                var responseJson = response.Content?.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // AlbumsLib //
        public async Task<bool> AlbumsLib_deleteAlbumLib(int albumsLibId)
        {
            try
            {
                string URLendpoint = $"{BaseUrl}/AlbumsLib/deleteAlbumLib";

                var response = await httpClient.DeleteAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<HttpResponseMessage> AlbumsLib_getAlbumLoad()
        {
            try
            {
                string URlendpoint = $"{BaseUrl}/AlbumsLib/getAlbumLoad";

                var response = await httpClient.GetAsync(URlendpoint);

                var responseJson = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }

        public async Task<bool> AlbumLib_addAlbum(int albumId)
        {
            try
            {
                var request = new
                {
                    albumId = albumId,
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"{BaseUrl}/AlbumsLib/addAlbum", content);

                var responseJson = response.Content?.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // AlbumsUser //
        public async Task<HttpResponseMessage> AlbumUser_getInfoAlbum(int albumId)
        {
            try
            {
                string URlendpoint = $"{BaseUrl}/AlbumsUser/getInfoAlbum?albumId={albumId}";

                var response = await httpClient.GetAsync(URlendpoint);

                var responseJson = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> AlbumUser_getOtherAlbum(int albumId, int artistId)
        {
            try
            {
                string URlendpoint = $"{BaseUrl}/AlbumsUser/getOtherAlbum?albumId={albumId}&artistId{artistId}";

                var response = await httpClient.GetAsync(URlendpoint);

                var responseJson = response.Content?.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> AlbumUser_findAlbum(string searchString)
        {
            try
            {
                string URLendpoint = $"{BaseUrl}/AlbumsUser/findAlbum?searchString={searchString}";

                var response = await httpClient.GetAsync(URLendpoint);

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> AlbumUser_albumLoad(int artistId)
        {
            try
            {
                string URlendpoint = $"{BaseUrl}/AlbumsUser/albumLoad?artistId={artistId}";

                var response = await httpClient.GetAsync(URlendpoint);

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        // ArtistLib //
        public async Task<bool> AlbumUser_deleteArtist(int artistsLibId)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/ArtistsLib/deleteArtist";

                var response = await httpClient.DeleteAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public async Task<HttpResponseMessage> AlbumUser_getArtistLoad()
        {
            try
            {
                string URLendpoint = $"{BaseUrl}/ArtistsLib/getArtistLoad";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content?.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public async Task<bool> AlbumUser_addArtist(int userId, int artistId)
        {
            try
            {
                var request = new
                {
                    userId = userId,
                    artistId = artistId
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson);

                var response = await httpClient.PostAsync($"{BaseUrl}/ArtistsLib/addArtist", content);

                var responseJson = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Files //
        public async Task<bool> Files_uploadFile(byte[] fileDetail, string name, string atribute)
        {
            try
            {
                var request = new
                {
                    fileDetail = fileDetail,
                    name = name,
                    atribute = atribute
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson);

                var response = await httpClient.PostAsync($"{BaseUrl}/Files/uploadFile", content);

                var responseJson = response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<HttpResponseMessage> Files_downloadFile(string path)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Files/downloadFile?path={path}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Files_downloadAlbumCover(string path)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Files/downloadAlbumCover?path={path}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Playlist //
        public async Task<bool> Playlist_createPlayList(int id)
        {
            try
            {
                var request = new
                {
                    id = id
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson);

                var response = await httpClient.PostAsync($"{BaseUrl}/Playlist/createPlaylist", content);

                var responseJson = response.Content?.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Playlist_addTrack(int playlistId, int trackId)
        {
            try
            {
                var request = new
                {
                    playlistId = playlistId,
                    trackId = trackId
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson);

                var response = await httpClient.PostAsync($"{BaseUrl}/Playlist/addTrack", content);

                var responseJson = response.Content?.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Playlist_addAlbum(int playlistId, int albumId)
        {
            try
            {
                var request = new
                {
                    playlistId = playlistId,
                    albumId = albumId
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson);

                var response = await httpClient.PostAsync($"{BaseUrl}/Playlist/addAlbum", content);

                var responseJson = response.Content?.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<HttpResponseMessage> Playlist_getPlaylistLoad(int id)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Playlist/getPlaylistLoad?id={id}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Playlist_getTrackLoad(int playlistId)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Playlist/getTrackLoad?playlistId={playlistId}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Playlist_getDuration(int playlistId)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Playlist/getDuration?playlistId={playlistId}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> Playlist_deltePlaylist(int playlistId)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Playlist/deletePlaylist?playlistId={playlistId}";

                var response = await httpClient.DeleteAsync(URLendpoint);

                var responseJson = response.Content?.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Playlist_updateTitle(int playlistId, string newTitle)
        {
            try
            {
                var request = new
                {
                    playlistId = playlistId,
                    newTitle = newTitle
                };

                var requestJson = JsonConvert.SerializeObject(request);

                var content = new StringContent(requestJson);

                var response = await httpClient.PutAsync($"{BaseUrl}/Playlist/updateTitle", content);

                var responseJson = response.Content?.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Playlist_deleteTrack(int playlistId, int trackId)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Playlist/deleteTrack?playlistId={playlistId}&trackId={trackId}";

                var response = await httpClient.DeleteAsync(URLendpoint);

                var responseJson = response.Content?.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Search //
        public async Task<HttpResponseMessage> Seach_getAlbums(string searchString)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Search/getAlbums?searchString={searchString}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Seach_getArtist(string searchString)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Search/getArtist?searchString={searchString}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Seach_getTracks(string searchString)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Search/getTracks?searchString={searchString}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Seach_getUsers(string searchString)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Search/getUsers?searchString={searchString}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Home //
        public async Task<HttpResponseMessage> Home_album()
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Home/album";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Home_artist()
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Home/artist";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Home_track()
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Home/track";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> Home_recentlyPlayed()
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Home/recentlyPlayed";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Play //
        public async Task<HttpResponseMessage> playTrack(int trackID)
        {
            try
            {
                var URLendpoint = $"{BaseUrl}/Play/{trackID}";

                var response = await httpClient.GetAsync(URLendpoint);

                var responseJson = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
