<?php
namespace Diplom;
class Authorization implements iAuthorization
{
    function CheckAuth() {
        $db = new DB();
        $db->Connect('param');
        $pass = $db->Query("select pass from $this->type where name=$this->name", 1);
        if(md5($this->pass) === $pass) :
            $this->MakeAuth();
        else :
            return false;
        endif;
    }
    function MakeAuth() {
        header('Location: ');
    }
}