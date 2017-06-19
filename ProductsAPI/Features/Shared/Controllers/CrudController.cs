using AutoMapper;
using ProductsDomain.Features.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Extensions;
using ProductsDomain.Exceptions;

namespace ProductsAPI.Features.Shared.Controllers
{
    public abstract class CrudController<S, D, C> : ApiController
    {
        private readonly IEntityService<D> _entityService;
        private readonly IMapper _mapper;

        public CrudController(
            IEntityService<D> entityService,
            IMapper mapper)
        {
            _entityService = entityService;
            _mapper = mapper;
        }

        [HttpGet, Route("")]
        public IHttpActionResult List(ODataQueryOptions<D> options)
        {
            var settings = new ODataQuerySettings { PageSize = 100 };
            IQueryable results = options.ApplyTo(_entityService.List(), settings);
            PageResult < S > output = new PageResult<S>(
                _mapper.Map<List<S>>(results) as IEnumerable<S>,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);

            return Ok<PageResult<S>>(output);
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Retrieve(int id)
        {
            return Ok(_mapper.Map<S>(_entityService.GetById(id)));
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_entityService.Delete(id));
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(C obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(
                    _mapper.Map<S>(
                        _entityService.Create(
                            _mapper.Map<D>(obj))));
            } catch(DuplicateEntryException e)
            {
                ModelState.AddModelError(e.FieldName, e);
                return BadRequest(ModelState);
            }
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Update(int id, C obj)
        {
            //get existing
            D existingObj = _entityService.GetById(id);

            //merge updates
            _mapper.Map<C, D>(obj, existingObj);

            return Ok(_mapper.Map<S>(_entityService.Update(existingObj)));
        }
    }
}