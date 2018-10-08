(function ($) {
    function AppRole() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-app-role").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new AppRole();
        self.init();
    })
}(jQuery))
