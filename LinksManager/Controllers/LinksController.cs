using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using LinksManager.DAL;
using LinksManager.DAL.Entities;
using LinksManager.DAL.Repository;
using LinksManager.Models;

namespace LinksManager.Controllers
{
    public class LinksController : ApiController
    {
        private readonly ILinkRepository _repository;

        public LinksController(ILinkRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LinkModel> GetLinks()
        {
            return Mapper.Map<IEnumerable<Link>, List<LinkModel>>(_repository.GetLinks());
        }

        public async Task<IHttpActionResult> GetLink(int id)
        {
            var link = await _repository.GetLinkByIdAsync(id);
            
            if (link == null)
            {
                return NotFound();
            }

            var linkModel = Mapper.Map<Link, LinkModel>(link);
            return Ok(linkModel);
        }

        public IEnumerable<LinkModel> GetLinksByCategory(string category)
        {
            var links = _repository.GetLinks().Where(
                l => string.Equals(l.Category, category, StringComparison.OrdinalIgnoreCase));

            return Mapper.Map<IEnumerable<Link>, List<LinkModel>>(links);
        }

        public async Task<IHttpActionResult> PostLink(LinkModel link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.InsertLinkAsync(Mapper.Map<LinkModel,Link>(link));
            return Ok();
        }

        public async Task<IHttpActionResult> DeleteLink(int id)
        {
            var link = await _repository.GetLinkByIdAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            await _repository.DeleteLinkAsync(id);
            return Ok(link);
        }

        public async Task<IHttpActionResult> PutLink(int id, LinkModel link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != link.Id)
            {
                return BadRequest();
            }

            if (_repository.GetLinks().Count(e => e.Id == id) > 0)
            {
                await _repository.UpdateLinkAsync(Mapper.Map<LinkModel, Link>(link));
            }
            else
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
