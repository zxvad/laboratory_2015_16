<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 21.04.2016
 * Time: 0:33
 */

namespace Smart\Server;


class AdminGui extends \GUI implements IAdminGui
{
    function Show()
    {
        $this->type = 'admin';
        $this->init();
    }

    function GetUsers()
    {
        $myUsers = new UsersGui();
        $myUsers->GetUsersList();
    }

    function GetUser()
    {
        $myUser = new UserGui();
        $myUser->GetUserInfo();

    }
}