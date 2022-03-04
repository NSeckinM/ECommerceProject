﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Services
{
    public class PictureService : IPictureService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAsyncRepository<Picture> _pictureRepository;

        public PictureService(ApplicationDbContext dbContext, IAsyncRepository<Picture> pictureRepository)
        {
            _dbContext = dbContext;
            _pictureRepository = pictureRepository;
        }
        public Task AddPicture(Picture picture)
        {
            Picture pic = new()
            {
                PictureUri = picture.PictureUri,
                ProductId = picture.ProductId
            };
            _pictureRepository.AddAsync(pic);
            return Task.FromResult(pic);
        }

        public async Task DeletePicture(int pictureId)
        {
            Picture picture = await _pictureRepository.GetByIdAsync(pictureId);
            _pictureRepository.Delete(picture);
        }

        public async Task UpdatePicture(Picture picture)
        {
            await _pictureRepository.UpdateAsync(picture);
        }
    }
}
