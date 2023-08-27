using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace PlanetsUtil
{
    public class CRUDAsssignmentsOperations : ICRUD<Assignment>
    {
        DBMappingContext context;

        public CRUDAsssignmentsOperations(DBMappingContext context)
        {
            this.context = context;
            
        }
        public bool Create(Assignment obj, out string errorMessage)
        {
            if (obj.planet <= 0)
            {
                errorMessage = "Planet Id is empty or negative.";
                return false;
            }
            if (obj.planetProperty <= 0)
            {
                errorMessage = "Planet Property Id is empty or negative.";
                return false;
            }

            if (context.AssignmentModel.Any(am => am.planet == obj.planet && am.planetProperty == obj.planetProperty))
            {
                errorMessage = "Assignment already exists in this system.";
                return false;
            }
            else
            {
                context.AssignmentModel.Add(obj);
                context.SaveChanges();
                errorMessage = null;
                return true;
            }
        }
        
        public void Update(Assignment assign)
        {
            Assignment assignement  = context.AssignmentModel.Find(assign.assignmentId);
            assignement = assign;
            context.SaveChanges();
            
        }
        public void Delete(Assignment assign)
        {
            context.AssignmentModel.Remove(assign);
            context.SaveChanges();
        }
        public List<Assignment> ReadAll()
        {
            return context.AssignmentModel.ToList<Assignment>(); 
        }
        public Assignment ReadById(int assignmentId)
        {
            Assignment asssignment = context.AssignmentModel.FirstOrDefault(x => x.assignmentId == assignmentId);
            return asssignment;
            
        }
        public Assignment ReadByPlanetId(int planetId)
        {
            Assignment asssignment = context.AssignmentModel.FirstOrDefault(x => x.planet == planetId);
            return asssignment;
        }
        public Assignment ReadByPropertyId(int propertyId)
        {
            Assignment asssignment = context.AssignmentModel.Single(x => x.planetProperty == propertyId);
            return asssignment;
        }

        public bool Exists(Assignment assign)
        {
            return context.AssignmentModel.Any(e => e.assignmentId == assign.assignmentId);
        }

        public static implicit operator CRUDAsssignmentsOperations(CRUDPlanetOperations v)
        {
            throw new NotImplementedException();
        }
    }
}
