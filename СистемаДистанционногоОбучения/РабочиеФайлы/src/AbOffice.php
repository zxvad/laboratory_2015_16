<?php
namespace Diplom;
abstract class AbOffice extends User
{
 public $login,$permissions;
    public function toOffice()
    {
        if($this->permissions=="student")
        {
            $usr=new StudentOffice();
        }
        if($this->permissions=="teacher")
        {
            $usr=new TeacherOffice();
        }
        if($this->permissions=="admin")
        {
            $usr=new AdminOffice();
        }
    }
}