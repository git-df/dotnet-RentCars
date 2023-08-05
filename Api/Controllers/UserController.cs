using Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Api.Controllers.AuthController;
using System.Security.Claims;
using MediatR;
using Application.Functions.Users.Commands.EditProfile;
using Application.Functions.Users.Queries.GetProfile;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<BaseResponse<GetProfileQueryVM>> GetProfile()
        {
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";

            return await _mediator.Send(new GetProfileQuery() { Id = Int32.Parse(stringClaimId)});
        }

        [Authorize]
        [HttpPatch]
        public async Task<BaseResponse> EditProfile([FromBody] EditProfileCommand request)
        {
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";

            request.SetId(Int32.Parse(stringClaimId));

            return await _mediator.Send(request);
        }

        [Authorize]
        [HttpGet]
        public BaseResponse<List<GetMenuVM>> GetMenu()
        {
            var role = (HttpContext.User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            switch (role)
            {
                case "Customer":
                    return new BaseResponse<List<GetMenuVM>>(new List<GetMenuVM>()
                    {
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Mój Profil", Route = "/profile"},
                        new GetMenuVM() {ClassCss = "tx-c3", Name = "Zarezerwuj", Route = "/rent"},
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Moje Zamówienia", Route = "/myorders"},
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Moje Płatności", Route = "/mypayments"},

                    });

                case "Employee":
                    return new BaseResponse<List<GetMenuVM>>(new List<GetMenuVM>()
                    {
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Mój Profil", Route = "/profile"},
                        new GetMenuVM() {ClassCss = "tx-c3", Name = "Zarezerwuj", Route = "/rent"},
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Moje Zamówienia", Route = "/myorders"},
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Moje Płatności", Route = "/mypayments"},
                        new GetMenuVM() {ClassCss = "text-warning", Name = "Zamówienia", Route = "/orders"},
                        new GetMenuVM() {ClassCss = "text-warning", Name = "Płatności", Route = "/payments"},
                        new GetMenuVM() {ClassCss = "text-warning", Name = "Oferty", Route = "/offers"},
                        new GetMenuVM() {ClassCss = "text-warning", Name = "Samochody", Route = "/models"}
                    });

                case "Admin":
                    return new BaseResponse<List<GetMenuVM>>(new List<GetMenuVM>()
                    {
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Mój Profil", Route = "/profile"},
                        new GetMenuVM() {ClassCss = "tx-c3", Name = "Zarezerwuj", Route = "/rent"},
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Moje Zamówienia", Route = "/myorders"},
                        new GetMenuVM() {ClassCss = "tx-c4", Name = "Moje Płatności", Route = "/mypayments"},
                        new GetMenuVM() {ClassCss = "text-warning", Name = "Zamówienia", Route = "/orders"},
                        new GetMenuVM() {ClassCss = "text-warning", Name = "Płatności", Route = "/payments"},
                        new GetMenuVM() {ClassCss = "text-warning", Name = "Oferty", Route = "/offers"},
                        new GetMenuVM() {ClassCss = "text-warning", Name = "Samochody", Route = "/models"},
                        new GetMenuVM() {ClassCss = "text-danger", Name = "Pracownicy", Route = "/employes"},
                        new GetMenuVM() {ClassCss = "text-danger", Name = "Oddziały", Route = "/branches"}
                    });

                default:
                    return new BaseResponse<List<GetMenuVM>>("Błąd użytkownika", false);
            }
        }

        public class GetMenuVM
        {
            public string Name { get; set; } = string.Empty;
            public string Route { get; set; } = string.Empty;
            public string ClassCss { get; set; } = string.Empty;
        }
    }
}
