using LocalizaAmigos.Domain.Entities;
using LocalizaAmigos.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalizaAmigos.Application
{
    public class AmigoApp
    {
        public static List<Amigo> ListaAmigosProximo(double Latitude, double Longitude, string login)
        {
            var _repositorio = new AmigoRepositorio();

            List<Amigo> LA = new List<Amigo>();
            List<Amigo> lista = _repositorio.Selecionar();
            Dictionary<double, Amigo> dc = new Dictionary<double, Amigo>();
            foreach (Amigo a in lista)
            {
                if (!(a.Latitude == Latitude && a.Longitude == Longitude))
                {
                    double distancia = CalcularDistancia(Latitude, Longitude, a.Latitude, a.Longitude);
                    a.Distancia = distancia;
                    dc.Add(distancia, a);
                }
            }

            var dic = dc.Keys.ToList();
            dic.Sort();

            int cont = 1;
            foreach (double a in dic)
            {
                if (cont < 4)
                {
                    LA.Add(dc[a]);
                    cont++;
                }
                else
                {
                    break;
                }
            }

            _repositorio.CalculoHistoricoLog_Insert(login, LA);
            return LA;


        }


        private static double CalcularDistancia(double origem_lat, double origem_lng, double destino_lat, double destino_lng)
        {
            double rlat1 = Math.PI * origem_lat / 180;
            double rlat2 = Math.PI * destino_lat / 180;
            double theta = origem_lng - destino_lng;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1.609344;
            
        }

        public static bool TokenIsValid(string token)
        {
            return Token.GetToken(token);
        }
    }
}
