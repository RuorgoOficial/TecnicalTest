using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Domain.Mappers
{
    public static class ImageMapper
    {
        public static ImageDTO Map(Image image)
        {
            return new ImageDTO()
            {
                medium = image.medium,
                original = image.original
            };
        }

        public static Image Map(ImageDTO image)
        {
            return new Image()
            {
                medium = image.medium,
                original = image.original
            };
        }
    }
}
