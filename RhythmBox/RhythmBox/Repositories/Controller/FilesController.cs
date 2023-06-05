using System;
using RhythmBox.Repositories;
using RhythmBox.Data;
using RhythmBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using RhythmBox.Repositories.Interface;

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

        [HttpPost("uploadFile")]
        public async Task<IActionResult> uploadFile([FromForm] FileDetails fileDetail, string name, string atribute)
        {
            if (fileDetail != null && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(atribute))
            {
                var artists = context.Artists
                                        .Where(con => con.FullName == name);

                var artist = artists.SingleOrDefault();

                if (artist != null)
                {
                    int artistId = artist.ArtistsId;

                    FileContent fileContent = new FileContent();

                    fileContent.fileName = fileDetail.fileDetail.FileName;

                    using (MemoryStream stream = new MemoryStream())
                    {
                        await fileDetail.fileDetail.CopyToAsync(stream);
                        fileContent.content = stream.ToArray();
                    }

                    string? fileUrl = await fileShare.fileUploadAsync(fileContent, artistId.ToString(), atribute, false);

                    return Ok(fileUrl);
                }
            }

            return BadRequest("Error");
        }

        [HttpGet("downloadFile")]
        public async Task<IActionResult> downloadFile(string path)
        {
            if (path != null)
            {
                try
                {
                    byte[] data = await fileShare.fileDownloadAsync(path);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("Error path");
        }

        [HttpGet("downloadAlbumCover")]
        public async Task<IActionResult> downloadAlbumCover(string path)
        {
            if (path != null)
            {
                try
                {
                    byte[] data = await fileShare.fileAlbumCoverDownloadAsync(path);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("Error path");
        }
    }
}


