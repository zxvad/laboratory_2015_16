<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 21.04.2016
 * Time: 0:26
 */

namespace Smart\Server;


class Admin implements iAdmin
{
    protected $isAuth, $curGui, $db;
    function ShowAuth(Auth $myAuth = null) {
        if($myAuth === null)
            $myAuth = new Auth('admin');
        $myAuth->ShowAuthForm();
        $this->isAuth = $myAuth->CheckAuth();
    }

    function ShowGui(AdminGui $myAdminGui = null) {
        if($myAdminGui === null)
            $myAdminGui = new AdminGui();
        $myAdminGui->Show();
    }

    function InitDB($param, DB $db = null) {
        if($db === null)
            $this->db = new DB();
        $this->db->Connect(1,2,3,4);
    }

    function ShowUsers(UsersGui $myUG = null) {
        if($myUG === null)
            $myUG = new UsersGui();
        $myUG->GetUsersList();
    }

}