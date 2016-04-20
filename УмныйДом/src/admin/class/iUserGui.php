<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 20.04.2016
 * Time: 23:30
 */

namespace Smart\Server;


interface iUserGui
{
    static function GetUserInfo(User $user);

    function EditUser(User $user);
}