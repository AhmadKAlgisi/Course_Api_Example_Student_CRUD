using System.Linq.Expressions;
using trinnig_course_api_example_student_CRUD.model;

namespace trinnig_course_api_example_student_CRUD.datasemlution
{
    public class data_acess_simlution
    {

        static public readonly List<student_class> students = new List<student_class>
        {
        new student_class{id=1,name="ahmad algisi",age=21,grade=96},
        new student_class{id=2,name="mohammed",age=10,grade=96 },
          new student_class{id=3,name="kgalled",age=30,grade=40 }
        };


        /// <summary>
        /// get oll student after fillter data when grade grether then 50
        /// </summary>
        /// <returns></returns>
        static public List<student_class> get_oll_student_passed()
        {

            List<student_class> s1 = students;
            List<student_class> s3 = new List<student_class>();
            foreach (student_class s2 in s1)
            { 
                if (s2.grade>=50)
                {
                    s3.Add(s2);
                }
              
   }
            return s3;
         

        }





     

    }
}
