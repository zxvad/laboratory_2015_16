<?php

/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 21.04.2016
 * Time: 1:05
 */
abstract class AbAuth
{
    public $type, $name, $pass;
    public function ShowAuthForm() {
        require_once("interface/auth/".$this->type.".html");
    }
}