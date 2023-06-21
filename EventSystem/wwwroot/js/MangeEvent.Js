$(document).ready(function () {
   
  

    $('#select').on('change', function (e) {
        var CateogryId = this.value;
        $.ajax({
            url: '/Event/MangeEvent',
            data:
            {
                CateogryId: CateogryId,
            }
        });


    });
    $('#EventTabel').on('click', 'tbody td #delete', function (e) {
        var EventId = $(this).data('id');
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


    });

});
