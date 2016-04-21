<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 21.04.2016
 * Time: 1:00
 */

namespace Smart\Server;


class Auth extends \AbAuth implements iAuth
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