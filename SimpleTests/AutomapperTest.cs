using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTests.Models;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using System.Collections.Generic;

namespace SimpleTests
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestInitialize]
        public void Init()
        {
            //Initiera AutoMapper
            //Vi wrappar alla mappningar i en Initialize istället för att bara skriva t.ex.
            //Mapper.CreateMap<Lag, SimpleLagVM>().ReverseMap();
            //Det gör vi för att det tydligen är mer effektivt
            AutoMapper.Mapper.Initialize(config =>
                {
                    config.CreateMap<Lag, SimpleLagVM>().ReverseMap();
                    config.CreateMap<Lag, LagVM>()
                        .ForMember(dest => dest.Namn, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.Tränare, opt => opt.MapFrom(src => src.Coach.Name));
                    config.CreateMap<LagVM, Lag>()
                        .ConvertUsing<LagVMTillLag>();
                    config.CreateMap<LagVM, SimpleLagVM>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Namn))
                        .ReverseMap();
                    config.CreateMap<Lag, AltLagVM>()
                        .ConvertUsing(src => {
                            var altis = new AltLagVM();
                            altis.Id = src.Id;
                            altis.Namn = src.Name;
                            altis.Tränare = string.Format("Coach {0} from {1}",src.Coach.Name, src.Coach.Country);
                            return altis; });
                });
        
        }

        [TestMethod]
        public void ConvertLagVMToLagUsingClass()
        {
            //Skapa lagVM
            var lagVm = new LagVM() { Id = 1, Namn = "Malmö FF" };
            var lagVm2 = new LagVM() { Id = 2, Namn = "HIF", Tränare = "Henke" };
            //Skapa lag med tränare
            var lag = new Lag();
            var tränare = new Member() { Id = 100, Name = "Åge Hareide", Country = "Norway" };
            lag.Coach = tränare;

            var lag2 = new Lag();
            var tränare2 = new Member() { Id = 110, Name = "Henrik Larsson", Country = "Sweden" };
            lag2.Town = "Helsingborg";
            //Konvertera
            //Observera att vi nu ska komplettera befintliga instanser
            Mapper.Map(lagVm, lag);
            Mapper.Map(lagVm2, lag2);
        }

        [TestMethod]
        public void SimpleLagMapping()
        {

            //Skapa lag
            var lag = new Lag() { Id = 1, Name = "Malmö FF", Country = "Sweden", Town = "Malmö" };
            //Skapa tränare
            var tränare = new Member() { Id = 100, Name = "Åge Hareide", Country = "Norway" };
            lag.Coach = tränare;
            //Convertera till SimpleLagVM
            var lagVm = Mapper.Map<Lag, SimpleLagVM>(lag);
            //Och tillbaka
            var nyttLag = Mapper.Map<SimpleLagVM, Lag>(lagVm);
            var annatLag = Mapper.Map<SimpleLagVM, LagVM>(lagVm);
            //Convertera Lag till AltLagVM
            AltLagVM altis = new AltLagVM();
            altis.Town = "Malmoe";
            altis = Mapper.Map<Lag, AltLagVM>(lag);
        }

        [TestMethod]
        public void CollectionLagMapping()
        {
            //Skapa lista av lag
            List<Lag> laglista = new List<Lag>();
            //Skapa lag
            var lag = new Lag() { Id = 1, Name = "Malmö FF", Country = "Sweden" };
            laglista.Add(lag);
            laglista.Add(new Lag() { Id = 2, Name = "Helsingborg IF", Country = "Sweden" });
            laglista.Add(new Lag() { Id = 3, Name = "IFK Göteborg", Country = "Sweden" });
            //Skapa tränare
            var tränare = new Member() { Id = 100, Name = "Åge Hareide", Country = "Norway" };
            lag.Coach = tränare;
            //Convertera till SimpleLagVM, i videon använder de List istället för ICollection.
            var lagVmCollection = Mapper.Map<ICollection<Lag>, ICollection<SimpleLagVM>>(laglista);
            var lagVmList = Mapper.Map<List<Lag>, List<SimpleLagVM>>(laglista);
        }

        [TestMethod]
        public void LagMapping()
        {
            //Skapa lag
            var lag = new Lag() { Id = 1, Name = "Malmö FF", Country = "Sweden" };
            //Skapa tränare
            var tränare = new Member() { Id = 100, Name = "Åge Hareide", Country = "Norway" };
            lag.Coach = tränare;
            //Convertera till LagVM
            var lagVm = Mapper.Map<Lag, LagVM>(lag);
        }

        [TestMethod]
        public void PlayerMapping()
        {
        }



    }

    public class LagVMTillLag : AutoMapper.ITypeConverter<LagVM, Lag>
    {
        public Lag Convert(AutoMapper.ResolutionContext context)
        {
            //Only support in-place conversion
            if (context.IsSourceValueNull || context.DestinationValue == null) return null;
            var src = (LagVM)context.SourceValue;
            var dst = (Lag)context.DestinationValue;
            dst.Id = src.Id;
            dst.Name = src.Namn;
            //Tilldela tränare endast om strängen innehåller något
            if (!string.IsNullOrEmpty(src.Tränare))
            {
                dst.Coach = new Member() { Name = src.Tränare};
            }
            return dst;
        }

    }
}
