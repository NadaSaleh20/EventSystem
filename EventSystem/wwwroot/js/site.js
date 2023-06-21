$(document).ready(function () {
    $('#EventTabel').on('click', 'tbody td #delete', function (e) {
     
        var EventId = $(this).data('id');
        Swal.fire({
            title: 'Do you want to Delete this Event?',
            showDenyButton: true,
            confirmButtonText: 'Yes',
            denyButtonText: `No`,
        }).then((result) => {
            if (result.isConfirmed) {
                
                $.ajax({
                    url: '/Event/DeleteEvent',
                    data:
                    {
                        EventId: EventId,
                    },
                    success: () => {
                        location.href = "https://localhost:44302/Event/MangeEvent";
                    }

                });

            }
            else if (result.isDenied) {
                Swal.fire('Changes are not saved', '', 'info')
            }
        })
    })

});
