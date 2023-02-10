using AutoMapper;
using MANUAL.API.Domain.Models;
using MANUAL.API.DTOResources;
using MANUAL.API.DTOResources.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskEntity = MANUAL.API.Domain.Models.TaskEntity;

namespace MANUAL.API.Mapping
{
    /*
     * Here I use Profile to orginize my mapping configuration. This class inherit from Profile class and put the configuration in the constructor
     * crating a mapping between Task Domain object and Task DTO Object. 
     * Profile is a class type that AutoMapper uses to check how our mappings will work.
     * AutoMappingProfile class inherits from Profile class and it will tell to AutoMapper how to handler classes mapping.
     */
    public class AutoMappingProfile : Profile
    {
     /*
     Insert mapping configuration for Task profile here in the constructor: CreateMap<Source Model Object,Destination DtoPOCO Object>();
     As soon as our application starts and initializes AutoMapper, AutoMapper will scan our application and look for classes that inherit from the Profile class and load their mapping configurations.


    If we have property with diferents names in our source and destination objects we have to costumize the mapping configuration for each individual property using ForMember method.

        eg:

        public class Task
        {
            public string Description {get; set; }
        }

        public class TaskDto
        {
        public string DtoDescription {get; set; }
        }

        Mapping Congiguration in Constructor:

        CreateMap<Task, taskDto>().
        ForMember( dest =>
        dest.DtoDescription,
        opt => opt.MapFrom(src => src.Description)
        ).ReverseMap();
     
    Here I am using Automapper's Reverse capability to achieve bi-directional mapping         

     */
         
        public AutoMappingProfile()
        {

            //Create mapping for entity relasionships many-to-many hidding the relation/join table table . Ref https://stackoverflow.com/questions/60261273/how-to-map-a-dto-with-a-many-to-many-relationship-to-a-ef-core-entity-with-a-rel
            //Here I am mapping Employee(Type EmployeeEntity) into employeeDtos (Type Ilist<EmployeeDto>), selecting de Employee form EmployeesTasks.dotnet

            CreateMap<TaskEntity, TaskDto>().ForMember(dto => dto.Employees, opt => opt.MapFrom( x => x.EmployeesTasks.Select(y => y.Employee.Name + " " + y.Employee.LastName).ToList())).ReverseMap();

            //-----------------------------------------
            /*
            Insert mapping configuration for Employee profile here in the constructor: CreateMap<Model Object, DtoPOCO>();
            As soon as our application starts and initializes AutoMapper, AutoMapper will scan our application and look for classes that inherit from the Profile class and load their mapping configurations.
            */
            CreateMap<EmployeeEntity, EmployeeDto>().ReverseMap();
        }
    }
}
