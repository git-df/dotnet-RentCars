using Application.Functions.Attributes.Commands.AddCarAtribute;
using Application.Functions.Attributes.Queries.GetCarAtributesByCar;
using Application.Functions.Auth.Commands.SignUp;
using Application.Functions.Branches.Commands.AddBranch;
using Application.Functions.Branches.Commands.EditBranch;
using Application.Functions.Branches.Queries.GetBranchDetails;
using Application.Functions.Branches.Queries.GetBranches;
using Application.Functions.Branches.Queries.GetContacts;
using Application.Functions.Cars.Commands.AddCar;
using Application.Functions.Cars.Queries.GetCar;
using Application.Functions.Cars.Queries.GetCarDetails;
using Application.Functions.Cars.Queries.GetCars;
using Application.Functions.Cars.Queries.GetCarsByModel;
using Application.Functions.Employes.Queries.GetBranchEmployes;
using Application.Functions.Employes.Queries.GetEmployes;
using Application.Functions.Employes.Queries.GetEmployesNoInBranch;
using Application.Functions.Models.Commands.AddModel;
using Application.Functions.Models.Commands.EditModel;
using Application.Functions.Models.Queries.GetModelsList;
using Application.Functions.Offers.Commands.AddOffer;
using Application.Functions.Offers.Queries.GetBranchesToOffer;
using Application.Functions.Offers.Queries.GetCarsToOffer;
using Application.Functions.Offers.Queries.GetOffers;
using Application.Functions.Payments.Queries.GetAllPayments;
using Application.Functions.Payments.Queries.GetMyPayments;
using Application.Functions.Rent.Queries.GetAllRents;
using Application.Functions.Rent.Queries.GetBranchesWithOfferts;
using Application.Functions.Rent.Queries.GetMyRents;
using Application.Functions.Rent.Queries.GetRentOptions;
using Application.Functions.Rent.Queries.GetRentOptionsDetails;
using Application.Functions.Users.Queries.GetProfile;
using Application.Functions.Users.Queries.GetUsersNoEmployee;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserInfoInSignUpCommand, UserInfo>();
            CreateMap<SignUpCommand, UserApp>();
            CreateMap<Car, GetCarsQueryVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CarsModel.BrandName + " " + src.CarsModel.ModelName + " (" + src.Year.ToString() + ")"));
            CreateMap<Branch, GetContactsQueryVM>();
            CreateMap<Address, AddressInGetContactsQueryVM>();
            CreateMap<Branch, BranchInGetBranchesQueryVM>();
            CreateMap<Branch, GetBranchDetailsQueryVM>();
            CreateMap<Address, AddressInGetBranchDetailsQueryVM>();
            CreateMap<AddressInAddBranchCommand, Address>();
            CreateMap<AddBranchCommand, Branch>();
            CreateMap<AddressInEditBranchCommand, Address>();
            CreateMap<UserEmployee, GetBranchEmployesQueryVM>();
            CreateMap<UserApp, UserAppInGetBranchEmployesQueryVM>();
            CreateMap<UserInfo, UserInfoInGetBranchEmployesQueryVM>();
            CreateMap<UserEmployee, GetEmployesNoInBranchQueryVM>();
            CreateMap<UserApp, UserAppInGetEmployesNoInBranchQueryVM>();
            CreateMap<UserInfo, UserInfoInGetEmployesNoInBranchQueryVM>();
            CreateMap<UserApp, GetProfileQueryVM>();
            CreateMap<UserInfo, UserInfoInGetProfileQueryVM>();
            CreateMap<UserEmployee, GetEmployesQueryVM>();
            CreateMap<UserApp, UserAppInGetEmployesQueryVM>();
            CreateMap<UserInfo, UserInfoInGetEmployesQueryVM>();
            CreateMap<UserApp, GetUsersNoEmployeeQueryVM>();
            CreateMap<UserInfo, UserInfoInGetUsersNoEmployeeQueryVM>();
            CreateMap<CarsModel, GetModelsListQueryVM>()
                .ForMember(dest => dest.CarsCount, opt => opt.MapFrom(src => src.Cars.Where(c => c.IsDeleted == false).Count()));
            CreateMap<AddModelCommand, CarsModel>();
            CreateMap<EditModelCommand, CarsModel>();
            CreateMap<CarsModel, CarsModelInGetCarsByModelQueryVM>();
            CreateMap<Car, GetCarsByModelQueryVM>()
                .ForMember(dest => dest.OffersCount, opt => opt.MapFrom(src => src.Offers.Count))
                .ForMember(dest => dest.RentsCount, opt => opt.MapFrom(src => src.Rents.Count));
            CreateMap<CarsModel, CarsModelInGetCarDetailsQueryVM>();
            CreateMap<Car, GetCarDetailsQueryVM>();
            CreateMap<AddCarCommand, Car>();
            CreateMap<CarAttribute, GetCarAtributesByCarQueryVM>();
            CreateMap<AddCarAtributeCommand, CarAttribute>();
            CreateMap<Car, GetCarQueryVM>();
            CreateMap<Branch, BranchInGetCarQueryVM>();
            CreateMap<Offer, OfferInGetCarQueryVM>();
            CreateMap<CarAttribute, CarAttributeInGetCarQueryVM>();
            CreateMap<CarsModel, CarsModelInGetCarQueryVM>();
            CreateMap<Offer, GetOffersQueryVM>();
            CreateMap<Car, CarInGetOffersQueryVM> ();
            CreateMap<CarsModel, CarsModelInGetOffersQueryVM> ();
            CreateMap<Branch, BranchInGetOffersQueryVM> ();
            CreateMap<AddOfferCommand, Offer>();
            CreateMap<Branch, GetBranchesWithOffertsQueryVM>();
            CreateMap<Car, GetRentOptionsQueryVM> ();
            CreateMap<CarsModel, CarsModelInGetRentOptionsQueryVM>();
            CreateMap<Car, GetCarsToOfferQueryVM>();
            CreateMap<CarsModel, CarsModelInGetCarsToOfferQuerryVM>();
            CreateMap<Branch, GetBranchesToOfferQueryVM>();
            CreateMap<Car, GetRentOptionsDetailsQueryVM>();
            CreateMap<CarsModel, CarsModelInGetRentOptionsDetailsQueryVM>();
            CreateMap<CarAttribute, CarAttributeInGetRentOptionsDetailsQueryVM>();
            CreateMap<Offer, OfferInGetRentOptionsDetailsQueryVM>();
            CreateMap<Branch, BranchInGetRentOptionsDetailsQueryVM>();
            CreateMap<Rent, GetMyRentsQueryVM>();
            CreateMap<Car, CarInGetMyRentsQueryVM>();
            CreateMap<CarsModel, CarsModelInCarInGetMyRentsQueryVM>();
            CreateMap<RentPayment, RentPaymentInGetMyRentsQueryVM>();
            CreateMap<RentPayment, GetMyPaymentsQueryVM>();
            CreateMap<Rent, RentInGetMyPaymentsQueryVM>();
            CreateMap<RentPayment, RentPaymentInGetAllRentsQueryVM>();
            CreateMap<UserApp, UserAppInGetAllRentsQueryVM>();
            CreateMap<CarsModel, CarsModelInGetAllRentsQueryVM>();
            CreateMap<Car, CarInGetAllRentsQueryVM>();
            CreateMap<Rent, GetAllRentsQueryVM>();
            CreateMap<RentPayment, GetAllPaymentsQueryVM>();
            CreateMap<Rent, RentInGetAllPaymentsQueryVM>();
            CreateMap<UserApp, UserAppInGetAllPaymentsQueryVM>();
        }
    }
}
