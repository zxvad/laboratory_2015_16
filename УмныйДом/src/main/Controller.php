<?
require_once "iController.php";
require_once "Interaction.php";
require_once "Alarm.php";
require_once "Handler.php";
class Controller implements iController
{
    private $handler;
    private $alarm;
    public function makeInteraction(Handler $handler){

    }
    public function makeAlarm(Alarm $alarm){

    }

}

?>