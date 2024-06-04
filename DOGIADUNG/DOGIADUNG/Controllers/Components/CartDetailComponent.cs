using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TECH.Areas.Admin.Models;
using TECH.Service;

namespace TECH.Controllers.Components

{
    [ViewComponent(Name = "CartDetailComponent")]
    public class CartDetailComponent : ViewComponent
    {
        private readonly ICartsService _cartsService;
        private readonly IOrdersService _ordersService;
        private readonly IAppUserService _appUserService;
        private readonly IProductsService _productsService;
        public IHttpContextAccessor _httpContextAccessor;
        private readonly IProductsImagesService _productsImagesService;
        private readonly IImagesService _imagesService;
        public CartDetailComponent(IOrdersService ordersService,
            IAppUserService appUserService,
             IHttpContextAccessor httpContextAccessor,
             ICartsService cartsService,
             IImagesService imagesService,
        IProductsImagesService productsImagesService,
        IProductsService productsService)
        {
            _ordersService = ordersService;
            _appUserService = appUserService;
            _imagesService = imagesService;
            _productsImagesService = productsImagesService;
            _cartsService = cartsService;
            _productsService = productsService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(int orderId)
        {
            var carts = new List<CartsModelView>();
            var userString = _httpContextAccessor.HttpContext.Session.GetString("UserInfor");
            var user = new UserModelView();
            if (userString != null)
            {
                user = JsonConvert.DeserializeObject<UserModelView>(userString);
                if (user != null)
                {
                    var model = _cartsService.GetAllCart(user.id);
                    if (model != null && model.Count > 0)
                    {
                        foreach (var item in model)
                        {
                            if (item.product_id.HasValue && item.product_id.Value > 0)
                            {
                                var _product = _productsService.GetByid(item.product_id.Value);
                                if (_product != null)
                                {
                                    var productImage = _productsImagesService.GetImageProduct(_product.id);
                                    if (productImage != null && productImage.Count > 0)
                                    {
                                        var image = _imagesService.GetImageName(productImage);
                                        if (image != null && image.Count > 0)
                                        {
                                            _product.ImageModelView = image;
                                        }
                                    }
                                    item.productModelView = _product;
                                }
                            }
                        }
                        carts = model;
                    }
                }
                return View(carts);
            }
            return View();
        }
    }
}