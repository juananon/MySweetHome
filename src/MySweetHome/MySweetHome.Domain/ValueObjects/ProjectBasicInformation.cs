using System;

namespace MySweetHome.Domain.ValueObjects
{
    public class ProjectBasicInformation
    {
        private readonly decimal _surface;
        private readonly int _floors;
        private readonly Quality _quality;

        public ProjectBasicInformation(decimal surface, int floors, Quality quality)
        {
            if (surface < 25)
            {
                throw new Exception("We cannot analyze projects with 25 meters or lower.");
            }
            if (floors < 1)
            {
                throw new Exception("We cannot analyze projects no floors.");
            }
            
            _surface = surface;
            _floors = floors;
            _quality = quality;
        }

        public decimal CalculatePrice()
        {
            return 0; //TODO: Calculate 
        }
    }
}