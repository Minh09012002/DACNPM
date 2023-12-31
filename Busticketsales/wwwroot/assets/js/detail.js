
var btnseat = document.querySelectorAll("button");
var btnbooking = document.getElementById("btn-booking");
var btnbookings = document.getElementById("btn-bookings");
var status = document.getElementById("Status");
var seatclbus = document.getElementsByClassName("bus-time-booking");
var seatls = document.querySelectorAll(".seat-l");

// xử lý trạng thái



var btnBooking = document.querySelectorAll(".seat-btn");
//var btnBooking = document.querySelectorAll(".bus-time-booking ");
var btnBookingArr = Array.from(btnBooking);
btnBookingArr.forEach(function (btnBK) {
    btnBK.addEventListener("click", function () {
        
       // var seatls = this.querySelectorAll(".bus-time-booking .seat-l");
        var seatls = btnBK.closest(".bookingSeat").querySelectorAll(".seat-l");
        var selectDiv = [seatls[0], seatls[1], seatls[6]];
        console.log(selectDiv);
        for (var i = 0; i < selectDiv.length; i++) {
            selectDiv[i].setAttribute("style", "background: #d6d6d6 ;  pointer-events:none;", true);
        }
        // Lưu trữ trạng thái của thẻ div khi click
        var divClicked = {};
        const seatBooking = btnBK.closest(".bookingSeat").querySelector("#Seat");
        seatls.forEach(function (seatElement) {

            seatElement.addEventListener("click", function () {
                var title = this.getAttribute('title');
                if (divClicked[title]) {
                    delete divClicked[title];
                    seatBooking.value = " ";
                } else {
                    divClicked[title] = true;
                    seatBooking.value = title;
                }


            })

        })
    })
})


seatls.forEach(function (seatl) {
    seatl.addEventListener("click", function () {
        if (this.classList.contains("active")) {
            seatl.classList.remove("active");
        } else {
            this.classList.add("active");
        }

    })

})


// Áp dụng lớp CSS cho các ghế dựa trên trạng thái
function applySeatStatus(seatStatusList) {
    var seatElements = document.querySelectorAll(".seat-l");
    seatElements.forEach(function (seat) {
        var Seat = parseInt(seat.dataset.Seat);
        var SeatStatus = seatStatusList.find(function (status) {
            return status.Seat === Seat;
        });
        if (seatStatus) {
            if (SeatStatus.status === 1) {
                seat.classList.add("booked");
            } else if (seatStatus.status === 2){ 
            seat.classList.add("rejected");
        }
    }
    });
}






// khi người dùng click vào huỷ vé xe
var CustomerDelete = document.getElementById("CustomerDelete");

CustomerDelete.addEventListener("click", function () {
    if (!confirm('Bạn có chắc chắn muốn xóa khách hàng này?')) {
        return false;
    }
})

