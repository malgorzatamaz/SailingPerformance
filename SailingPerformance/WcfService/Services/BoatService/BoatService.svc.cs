﻿using System;
using AutoMapper;
using Dal;
using Dal.Repositories;
using Dal.Repositories.Contracts;
using WcfService.AutoMapper;

namespace WcfService.Services.BoatService
{
    /// <summary>
    ///  implementacja interfejsu
    /// </summary>
    public class BoatService : IBoatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BoatRepository _repositoryBoat;
        public BoatService()
        {
            SailingDbContext context = new SailingDbContext();
            _repositoryBoat = new BoatRepository(context);
            _unitOfWork = new UnitOfWork(context);
            AutoMapperConfiguration.Configuration();
        }
        /// <summary>
        /// udostępniona metoda dodania łódki do bazy
        /// </summary>
        /// <param name="boatRequest"></param>
        /// <returns>zwracana odpowiedź czy udało się dodać lódkę do bazy
        /// </returns>
        public BaseResponse AddBoat(BoatRequest boatRequest)
        {
            var response = new BaseResponse();
            try
            {
                _unitOfWork.BeginTransaction();
                var check = _repositoryBoat.GetGuidBoat(boatRequest.Model, boatRequest.Name);
                if (check == Guid.Empty)
                {
                    Boat boat = Mapper.Map<Boat>(boatRequest);
                    boat.IdBoat=Guid.NewGuid();
                    _repositoryBoat.Add(boat);
                    _unitOfWork.Commit();
                    response.IsSuccess = true;
                }
                else
                {
                    _unitOfWork.Commit();
                    response.IsSuccess = false;
                    response.ErrorMessage = "Łódka o takiej nazwie i modelu juz istnieje";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.ToString();
            }
            return response;
        }
        /// <summary>
        /// udostępniona metoda aktyalizacji danych o łódce
        /// </summary>
        /// <param name="boatRequest"></param>
        /// <returns>zwracana odpowiedź czy udalo się zaktualizować dane</returns>
        public BaseResponse UpdateBoat(BoatRequest boatRequest)
        {
            var response = new BaseResponse();
            try
            {
                _unitOfWork.BeginTransaction();
                var check = _repositoryBoat.GetGuidBoat(boatRequest.Model, boatRequest.Name);
                if (check != Guid.Empty)
                {
                    Boat boat = Mapper.Map<Boat>(boatRequest);
                    _repositoryBoat.Update(boat);
                    _unitOfWork.Commit();
                    response.IsSuccess = true;
                }
                else
                {
                    _unitOfWork.Commit();
                    response.IsSuccess = false;
                    response.ErrorMessage = "Łódka o takiej nazwie i modelu nie istnieje";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.ToString();
            }
            return response;
        }
        /// <summary>
        /// udostępniona metoda pobierania Id łódki
        /// </summary>
        /// <param name="boatRequest"></param>
        /// <returns>zwracana odpowiedź czy udało się pobrać Id</returns>
        public GetBoatResponse GetBoatId(BoatRequest boatRequest)
        {
            var response = new GetBoatResponse();
            try
            {
                _unitOfWork.BeginTransaction();
                var check = _repositoryBoat.GetGuidBoat(boatRequest.Model, boatRequest.Name);
                if (check != Guid.Empty)
                {
                    response.Id = check;
                    _unitOfWork.Commit();
                    response.IsSuccess = true;
                }
                else
                {
                    _unitOfWork.Commit();
                    response.IsSuccess = false;
                    response.ErrorMessage = "Nie istnieje łódki o takim id";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.ToString();
            }
            return response;
        }
        /// <summary>
        /// udostępniona metoda usunięcia łódki
        /// </summary>
        /// <param name="request"></param>
        /// <returns>zwracana odpowiedź czy udalo się usunąc łódkę</returns>
        public BaseResponse DeleteBoat(DeleteBoatRequest request)
        {
            var response = new BaseResponse();
            try
            {
                _unitOfWork.BeginTransaction();
                _repositoryBoat.Delete(new Boat { IdBoat = new Guid("BF1D73AB-356C-48F8-94EA-34F872EC3535") });
                _unitOfWork.Commit();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.ToString();
            }
            return response;
        }
    }
}
