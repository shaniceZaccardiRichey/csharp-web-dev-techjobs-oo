using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        // TODO: Generate Equals() and GetHashCode() methods.

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString() 
        {
            string output;

            if (this.Name == null &&
                this.EmployerName == null &&
                this.EmployerLocation == null &&
                this.JobType == null &&
                this.JobCoreCompetency == null)
            {
                output = "OOPS! This job does not seem to exist.";
            }
            else 
            {
                string nameString = this.Name;
                string employerNameString = this.EmployerName.Value;
                string locationString = this.EmployerLocation.Value;
                string positionTypeString = this.JobType.Value;
                string coreCompetencyString = this.JobCoreCompetency.Value;

                if (nameString == "") { nameString = "Data not available."; }
                if (employerNameString == "") { employerNameString = "Data not available."; }
                if (locationString == "") { locationString = "Data not available."; }
                if (positionTypeString == "") { positionTypeString = "Data not available."; }
                if (coreCompetencyString == "") { coreCompetencyString = "Data not available."; }

                output = $"\nID: {this.Id}" +
                         $"\nName: {nameString}" +
                         $"\nEmployer: {employerNameString}" +
                         $"\nLocation: {locationString}" +
                         $"\nPosition Type: {positionTypeString}" +
                         $"\nCore Competency: {coreCompetencyString}" +
                          "\n";
            }

            return output;
        }

    }
}
