﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace WebObjectDataSource.App_Code
{
    public class XMLObjectCityRepository:IRepository
    {
        ObjectCityRepository obcr = new ObjectCityRepository();
         
        public IEnumerable<City> GetCityCollection()
        {
            return obcr.GetCityCollection().ToList();    
        }

        public void CreateXMLDocument(string path)
        {
            List<City> citys = this.GetCityCollection().ToList();
            XDocument xdoc = new XDocument();
            XElement xCitys = new XElement("Citys");

            foreach (City city in citys)
            {
                XElement cityElem = new XElement("City");
                XAttribute elemName = new XAttribute("name", city.NameCity);
                XElement areaElem = new XElement("area", city.Area);
                XElement populationElem = new XElement("population", city.Population);
                cityElem.Add(elemName);
                cityElem.Add(areaElem);
                cityElem.Add(populationElem);
                xCitys.Add(cityElem);
            }

            xdoc.Add(xCitys);
            xdoc.Save(path + "/citys.xml");
        }      
    }
}