using System;
namespace Pizzas.API.Models
{
    public class Pizza
    {
        private int _id;
        private string _nombre;
        private bool _libreGluten;
        private float _importe;
        private string _descripcion;

        public Pizza(int id, string nombre, bool libreGluten, float importe, string descripcion)
        {   
            _id = id;
            _nombre = nombre;
            _libreGluten = libreGluten; 
            _importe = importe;
            _descripcion = descripcion;
        }
        public Pizza(){}
         public int id
        {
            get {return _id;}
            set {_id = value;}
        }
        public string nombre
        {
            get {return _nombre;}
            set {_nombre = value;}
        }
        public bool libreGluten
        {
            get {return _libreGluten;}
            set {_libreGluten = value;}
        }  
         public float importe
        {
            get {return _importe;}
            set {_importe = value;}
        }
        public string descripcion
        {
            get {return _descripcion;}
            set {_descripcion = value;}
        }
     
    }
}
