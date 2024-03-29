﻿using HotelReservation.Models;
using System.Runtime.Serialization;

namespace HotelReservation.Exceptions;
public class ReservationConflictException : Exception
{
    public Reservation ExistingReservation { get; }
    public Reservation IncomingReservation { get; }
    public ReservationConflictException(Reservation existingReservation, Reservation incomingReservation)
    {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }

    public ReservationConflictException(string? message, Reservation existingReservation, Reservation incomingReservation) : base(message)
    {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }

    public ReservationConflictException(string? message, Exception? innerException, Reservation existingReservation = null, Reservation incomingReservation = null) : base(message, innerException)
    {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }

    protected ReservationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }


}
