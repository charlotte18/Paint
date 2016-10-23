using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Singleton
    {
        private static Singleton instance; 
        
        public int SelectedColorIndex;
        public int SelectedWidthIndex;
        public int SelectedBGColorIndex;
        public int SelectedShapeIndex;

        protected Singleton()
        {
            this.SelectedColorIndex = 0;
            this.SelectedWidthIndex = 0;
            this.SelectedBGColorIndex = 0;
            this.SelectedShapeIndex = 0;
        }

        public static Singleton Instance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
