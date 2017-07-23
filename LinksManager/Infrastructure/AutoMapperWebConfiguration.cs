using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LinksManager.DAL.Entities;
using LinksManager.Models;

namespace LinksManager.Infrastructure
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Link, LinkModel>();
                    cfg.CreateMap<LinkModel, Link>();
                }
            );
            
        }
    }
}