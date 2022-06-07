using Mango.Services.API.Models;
using Mango.Services.API.Models.Dto;
using Mango.Services.API.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.API.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : Controller
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result= productDtos;
            }catch(Exception ex)
            {
                _response.IsSuccess = false; ;
                _response.ErrorMessages = new System.Collections.Generic.List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDtos = await _productRepository.GetProductById(id);
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false; ;
                _response.ErrorMessages = new System.Collections.Generic.List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false; ;
                _response.ErrorMessages = new System.Collections.Generic.List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false; ;
                _response.ErrorMessages = new System.Collections.Generic.List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        public async Task<object> Delete([FromBody] int id)
        {
            try
            {
                bool isSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false; ;
                _response.ErrorMessages = new System.Collections.Generic.List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
