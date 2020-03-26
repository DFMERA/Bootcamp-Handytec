
SELECT * FROM hotel_bookings

select reservation_status, count(*) FROM hotel_bookings
group by reservation_status



Select lead_time, reserved_room_type,assigned_room_type,
adr,country,booking_changes,* 
from hotel_bookings
where reservation_status = 'Check-Out'
'Canceled'
'Booking-Changed'


