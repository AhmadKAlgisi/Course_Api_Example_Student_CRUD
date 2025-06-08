using Businees_Logic_Layer;
using Data_access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
using trinnig_course_api_example_student_CRUD.datasemlution;
using trinnig_course_api_example_student_CRUD.model;
using static Businees_Logic_Layer.Student_Businnes;

namespace trinnig_course_api_example_student_CRUD.Controllers
{
    [Route("api/MY_CURD_STUDENT_")]
    [ApiController]
    public class MY_CURD_STUDENT_CONTROLLER : ControllerBase
    {
        [HttpGet("all_student", Name = "all_student")]
        public ActionResult<IEnumerable<DTO_student>> get_all_styudent()///action result هو وعاء كبير بستقبل منك اي نوع داتا وبرجعها 
            //ienumercable هاي بتخليك تعمل لوب لحالو من خلا foreachللاوبجكنت من نوع students class مفيدة ايضا في الديكومنتسشن لو شلتها فقط تؤثر على الديكو 
        {
            return Ok(Student_Businnes.get_oll_student());
        }





        [HttpGet("get_passed_students", Name = "get_passed_students")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DTO_student>> get_all_styudent_IN_Passed()///action result هو وعاء كبير بستقبل منك اي نوع داتا وبرجعها 
            //ienumercable هاي بتخليك تعمل لوب لحالو من خلا foreachللاوبجكنت من نوع students class مفيدة ايضا في الديكومنتسشن لو شلتها فقط تؤثر على الديكو 
        {
            //return Ok(data_acess_simlution.students.Where(student_class => student_class.grade >= 50));// بحيث ترجع كود من السرفر status code 


            List<DTO_student> s1 = Student_Businnes.get_all_student_passed();

            if (s1.Count() > 0)

                return Ok(s1);
            else
                return NotFound("not found data ....");
            

        }




        [HttpGet("get_passed_students2", Name = "get_passed_students2")]
        public ActionResult<IEnumerable<student_class>> get_all_styudent_IN_Passed2()///action result هو وعاء كبير بستقبل منك اي نوع داتا وبرجعها 
            //ienumercable هاي بتخليك تعمل لوب لحالو من خلا foreachللاوبجكنت من نوع students class مفيدة ايضا في الديكومنتسشن لو شلتها فقط تؤثر على الديكو 
        {
            return Ok(data_acess_simlution.get_oll_student_passed());// بحيث ترجع كود من السرفر status code 
        }





        [HttpGet("getavrg", Name = "getavrg")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<double> averge_grade()
        {

            double avg = Student_Businnes.get_avg_student();
            return Ok(avg);


        }




    

        [HttpGet("{id}",Name="get_student_by_id" )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DTO_student> get_student__by_id(int id)
        {
            if (id <=0)
            {
                return BadRequest($"the id {id} bad id .....");
            }

            Student_Businnes s1 = Student_Businnes.get_student_by_id(id);

            if (s1 != null)
            {
                DTO_student s2 = s1.SDTO;
                return Ok(s2);



            }
            else
            {
                return NotFound($"the id :  {id}  not found .... ");
            }

        }





        //[HttpPost("new prson", Name = "new person")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]

        //public ActionResult<DTO_student> add_new_person(DTO_student new_student)
        //{
        //    if (new_student.name != null || new_student.grade != null || new_student.age != null)
        //    {
        //        Student_Businnes student = new Student_Businnes(new_student, enmode.ADDNEW);

              
        //    }

        //    else
        //    return BadRequest("the contant bad becuse not compleated data ....");
        //}



        [HttpDelete("delete person {id}",Name= "delete person")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> delete_person(int id)
        {
            if (id >= 1)
            {
               student_class s1= data_acess_simlution.students.FirstOrDefault(student_class => student_class.id == id);
                if (s1 != null)
                {
                    data_acess_simlution.students.Remove(s1);
                    return Ok($"the person id : {id} completed deleted ....");

                }
                else
                    return NotFound("the person not found ...");

            }
            else
                return BadRequest($"the id : {id} bad ... ");
        }






        [HttpPut("update person ",Name = "update person ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<student_class> update_person(int id,student_class student)
        {
            if(student.id<1||student.name==null|| student.grade<1|| student.age<0)
            {
                return BadRequest("the request data error ....");
            }
            else
            {
                student_class s1 = data_acess_simlution.students.FirstOrDefault(student_class => student_class.id == id);
                if (s1 != null)
                {

                    s1.name = student.name;
                    s1.grade = student.grade;
                    s1.age = student.age;
                    return Ok($"update data : {s1.id}");

                }
                else
                    return NotFound("the person not found ...");

            }

        }





        




    }
}
