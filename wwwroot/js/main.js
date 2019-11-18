var $duration = 300;
$(document).ready(function () {
    // - ACCOUNT DROPDOWN
    $('.ui.admindropdown').dropdown({
        transition: 'swing down',
        on: 'click',
        duration: $duration
    });

    $('.ui.sidebardropdown').dropdown({
        transition: 'swing left',
        on: 'click',
        duration: $duration
    });
    $('.ui.moredropdown').dropdown({
        transition: 'swing down',
        duration: $duration
    });

    // - SHOW & HIDE SIDEBAR
    $("#showmobiletabletsidebar").click(function () {
        $('.mobiletabletsidebar.animate .menu').transition({
            animation: 'swing right',
            duration: $duration
        })
        ;
        $('#mobiletabletsidebar').removeClass('hidden');
    });
    $("#hidemobiletabletsidebar").click(function () {
        $('.mobiletabletsidebar.animate .menu')
            .transition({
                animation: 'fade',
                duration: $duration
            });
    });
    // - DATA TABLES
    $(document).ready(function () {
        $('#example').DataTable();
    });
    var table = $('#example').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });
    table.buttons().container()
        .appendTo($('div.eight.column:eq(0)', table.table().container()));
    //FORMS
    $('#createRolFom').form({
        fields: {
            rolName: {
                identifier: 'rolName',
                rules: [
                    {
                        type: 'empty',
                        prompt: 'Please enter a rol name'
                    }
                ]
            }
        }
    });
    //MODALS
    $('#showRolesModal').on('click', function () {
        $('#addRolesModal')
            .modal('setting', 'closable', false)
            .modal('show')
        ;
    });
    $('#submitCreateRol').on('click', function () {
        $('#createRolFom').submit()
    });
    
    var showModalButton = $('.ui.icon.button');
    showModalButton.on('click', function (event) {
        $('#editUserRoles')
            .modal({
                onShow: function () {
                    var button = event.currentTarget;
                    $('#emailToSend').val(button.attributes['data-email'].value);
                }
            })
            .modal('setting', 'closable', false)
            .modal('show')
        ;
        //DROPDOWNS
        $('#rolesSelected')
            .dropdown({
                maxSelections: 3
            })
        ;
    });

    var sendEditRole = $('.ui.positive.right.labeled.icon.button');
    sendEditRole.on('click', function () {
        $('#sendRolesRequest').submit();
    })

});