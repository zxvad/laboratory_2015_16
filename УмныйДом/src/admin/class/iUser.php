<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 21.04.2016
 * Time: 1:24
 */

namespace Smart\Server;


interface iUser
{
    function SendNote();

    function AddModule($module);

    function DeleteModule($module);
}