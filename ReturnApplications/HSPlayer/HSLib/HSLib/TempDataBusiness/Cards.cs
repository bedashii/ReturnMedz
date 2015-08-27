using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempDataGenLib.Business
{
    public partial class Cards : Data.CardsData
    {
        private int _count = 0;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public Cards()
        {

        }

        /// <summary>
        /// This method can be used to do some preparation work 
        /// before any of the generated contructor do any processing
        /// </summary>
        private void PrepareBeforeConstruction()
        {
        }

        /// <summary>
        /// This method can be used to do some finalization work
        /// after the generated contructor did it's processing
        /// </summary>
        private void FinishAfterConstruction()
        {
        }

    }


}
