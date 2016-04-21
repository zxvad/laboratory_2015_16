<?php
namespace Diplom;
class TeacherOffice extends AbOffice implements Communication, iTeacherOffice
{
    function TextMessage()
    {}
    function VideoMassage()
    {}
    function CourseList()
    {}
    function NewCourse()
    {
        $constract1 = new CourseConstruct();
        $constract2 = new TestConstruct();
    }
    function StudentsList()
    {}
    function TasksCheck()
    {
        function ShowResults()
        {}
        $marktasks = new GiveMark();
    }
    function ChangePassword()
    {}
}