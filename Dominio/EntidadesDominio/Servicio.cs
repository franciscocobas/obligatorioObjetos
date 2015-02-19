using System;
using System.Collections.Generic;
namespace Dominio.EntidadesDominio
{
    public class Servicio
    {
        private int id;
        private static int ultId;
        private String descripcion;
        private byte edadMin;
        private Precio costoDiario;
        private byte edadMax;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static int UltId
        {
            get { return Servicio.ultId; }
            set { Servicio.ultId = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public Precio CostoDiario
        {
            get { return costoDiario; }
            set { costoDiario = value; }
        }

        public byte EdadMin
        {
            get { return edadMin; }
            set { edadMin = value; }
        }

        public byte EdadMax
        {
            get { return edadMax; }
            set { edadMax = value; }
        }
        public Servicio(string desc, Precio costoDia , byte edadMin, byte edadMax)
        {
            this.Descripcion = desc;
            this.CostoDiario = costoDia;
            this.EdadMin = EdadMin;
            this.edadMax = edadMax;
        }
        public override bool Equals(object obj)
        {
            Servicio s = obj as Servicio;
            if (s== null) return false;
            return this.Descripcion.ToUpper().Trim ()==s.Descripcion .ToUpper().Trim();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

}

