namespace IoBTMessage.Models;
using TurfCS;

public class VirtualSquire
{
    public string PanID { get; set; }
    public string SquadID { get; set; }
    public UDTO_Position CurrentPosition { get; set; }
    public UDTO_ChatMessage LastChatMessage { get; set; }
    public UDTO_Objective LastObjective { get; set; }
    public UDTO_Observation LastObservation { get; set; }
    public UDTO_Biometric LastBiometric { get; set; }

    protected double speed { get; set; } = 0;
    protected double heading { get; set; } = 0;
    protected double faceing { get; set; } = 0;

    protected bool isPaused { get; set; } = false;
    public VirtualSquire()
    {
    }
    public VirtualSquire(VirtualSquire source)
    {
        this.CurrentPosition = source.CurrentPosition.Duplicate<UDTO_Position>();
        this.Speed(source.speed);
        this.Faceing(source.faceing);
        this.Heading(source.heading);
    }


    public VirtualSquire Position(UDTO_Position pos)
    {
        this.CurrentPosition = pos.Duplicate<UDTO_Position>();
        return this;
    }

    public VirtualSquire Position(double lat, double lng, double alt = 0)
    {
        return Position(new UDTO_Position()
        {
            lat = lat,
            lng = lng,
            alt = alt
        });
    }

    public VirtualSquire Pause(bool pause)
    {
        this.isPaused = pause;
        return this;
    }

    public VirtualSquire Speed(double speed)
    {
        this.speed = speed;
        return this;
    }
    public VirtualSquire Faceing(double faceing)
    {
        this.faceing = faceing;
        return this;
    }
    public VirtualSquire Heading(double heading)
    {
        this.heading = heading;
        return this;
    }

    public VirtualSquire Turn(double angle)
    {
        this.heading += angle;
        return this;
    }

    public VirtualSquire ComputeStep(double delta, int frameID)
    {
        if ( !this.isPaused ) {
            var pos = this.CurrentPosition;
            var feature = pos.destination(delta * this.speed, this.heading);
            var loc = feature.toLatLng();

            this.CurrentPosition.lat = loc[1];
            this.CurrentPosition.lng = loc[0];
        }
        return this;
    }

    public VirtualSquire TimeStep(double delta, int frameID)
    {
        if ( !this.isPaused ) {
            this.ComputeStep(delta, frameID);
        }
        return this;
    }
}

