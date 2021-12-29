using MediatR;
using ProductApi.Data.Repository;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProductApi.Messaging.Send.Sender;
using ProductApi.Messaging.Send.Models;

namespace ProductApi.Service.Command
{
    public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand,Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUpdateProductSender _updateproductSender;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUpdateProductSender updateProductSender)
        {
            _productRepository = productRepository;
            _updateproductSender = updateProductSender;
        }
        public async Task<Product> Handle(UpdateProductCommand request,CancellationToken cancellationtoken)
        {
            //Product pre_product = await _productRepository.GetProductByIdAsync(request.Product.ProductGuid,cancellationtoken); 
            Product product= await _productRepository.UpdateAsync(request.Product);
            UpdatedProductPriceModel priceModel =  new UpdatedProductPriceModel()
            {
                Id = product.Id,
                Price = product.Price,
                ProductId = product.ProductGuid
            };
            //if(pre_product.Price!=product.Price)
            //{
             _updateproductSender.SendProduct(priceModel);
            //}
            return product;
        }
    }
}
