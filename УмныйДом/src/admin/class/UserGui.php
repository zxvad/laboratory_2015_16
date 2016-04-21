<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 21.04.2016
 * Time: 1:16
 */

namespace Smart\Server;


class UserGui extends \GUI implements iUserGui
{
    protected $user;
    function __construct(User $user) {
        $this->user = $user;
    }
    static function GetUserInfo(User $user) {

    }

    function EditUser(User $user) {

    }
}