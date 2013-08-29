using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotaDbGenLib.Business
{
    public partial class MatchPlayer : Data.MatchPlayerData
    {
        public MatchPlayer()
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

        public void GetByMatchPlayer64(int matchID, long player64)
        {
            base.LoadByMatchPlayer64(matchID, player64);
        }
    }
    

}
