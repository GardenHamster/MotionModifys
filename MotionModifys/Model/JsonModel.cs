using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionModifys.Model
{
    public class JsonModel
    {
        public object Version { get; set; }

        public object Meta { get; set; }

        public List<CurvesModel> Curves { get; set; }

    }

    public class CurvesModel
    {
        public object Target { get; set; }

        public string Id { get; set; }

        public object Segments { get; set; }
    }




}
