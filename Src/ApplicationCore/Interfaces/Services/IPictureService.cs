using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IPictureService
    {
        Task AddPicture(Picture picture);
        Task UpdatePicture(Picture picture);
        Task DeleteOffer(int pictureId);

    }
}
