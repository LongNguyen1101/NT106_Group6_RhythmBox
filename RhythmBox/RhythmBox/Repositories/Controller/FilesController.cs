using System;
using RhythmBox.Repositories;
using RhythmBox.Data;
using RhythmBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace RhythmBox.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
	{
        private readonly IFileShare fileShare;
        private readonly RhythmboxdbContext context;

        public FilesController(RhythmboxdbContext context, IFileShare fileShare)
        {
            this.fileShare = fileShare;
            this.context = context;
        }

        /// <summary>
        /// upload file
        /// </summary>
        /// <param name="fileDetail"></param>
        /// <returns></returns>
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile([FromForm] FileDetails fileDetail, string artistName, string atribute)
        {
            if (fileDetail.fileDetail != null && !string.IsNullOrEmpty(artistName) && !string.IsNullOrEmpty(atribute))
            {
                var artists = context.Artists
                                        .Where(con => con.FullName == artistName);

                var artist = artists.SingleOrDefault();

                if (artist != null)
                {
                    int artistId = artist.ArtistsId;
                    await fileShare.fileUploadAsync(fileDetail, artistId.ToString(), atribute, false);
                }
            }
            return Ok();
        }

        /// <summary>
        /// download file
        /// </summary>
        /// <param name="fileDetail"></param>
        /// <returns></returns>
        [HttpPost("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            if (fileName != null)
            {
                await fileShare.fileDownloadAsync(fileName);
            }
            return Ok();
        }
    }
}


