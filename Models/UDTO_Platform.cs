namespace IoBTMessage.Models;

[System.Serializable]
public class UDTO_Platform : UDTO_3D
{
    public UDTO_Position position { get; set; }
    public BoundingBox boundingBox { get; set; }

 
    private readonly Dictionary<string, UDTO_Body> _bodyLookup = new();

    public List<UDTO_Body> bodies
    {
        get
        {
            return _bodyLookup.Select(pair => pair.Value).ToList();
        }
        set
        {
            if (value != null)
            {
                value.ForEach(item => EstablishBody(item, false));
            }
            else
            {
                _bodyLookup.Clear();
            }
        }
    }

    private readonly Dictionary<string, UDTO_Label> _labelLookup = new();

    public List<UDTO_Label> labels
    {
        get
        {
            return _labelLookup.Select(pair => pair.Value).ToList();
        }
        set
        {
            if (value != null)
            {
                value.ForEach(item => EstablishLabel(item, false));
            }
            else
            {
                _labelLookup.Clear();
            }
        }
    }


    public void Merge(UDTO_Platform platform)
    {
        if (platform.position != null)
        {
            this.position = platform.position;
        }
        if (platform.boundingBox != null)
        {
            this.boundingBox = platform.boundingBox;
        }

        platform.bodies.ForEach(body =>
        {
            EstablishBody(body);
        });
        platform.bodies = null;

        platform.labels.ForEach(label =>
        {
            EstablishLabel(label);
        });
        platform.labels = null;
    }


    public override string compress(char d = ',')
    {
        // Optional param in body compress function lets us use a semicolon instead of a comma as a delimeter 
        var bodies = this.bodies.Select(item => item.compress('!')).ToList();
        var bodycount = bodies.Count;
        var platform = $"{base.compress(d)}{d}{position?.compress(d)}{d}{boundingBox?.compress(d)}";
        if (bodycount > 0)
        {
            var body = bodies.First();
            var rest = String.Join(",", bodies);
            return $"{platform},{rest}";
        }

        return platform;
    }
    public override int decompress(string[] data)
    {
        var counter = base.decompress(data);

        platformName = data[counter++];

        if (data[counter] != String.Empty)
        {
            position = new UDTO_Position();
            var seg = new ArraySegment<string>(data, counter, data.Length - counter);
            counter += position.decompress(seg.ToArray());
        }
        else
        {
            counter++;
        }

        if (data[counter] != String.Empty)
        {
            boundingBox = new BoundingBox();
            var seg = new ArraySegment<string>(data, counter, data.Length - counter);
            counter += boundingBox.decompress(seg.ToArray());
        }
        else
        {
            counter++;
        }

        // Now rehydrate all the bodies 
        // Bodies are separated by commas, but internal fields are separated by semicolons
        // At this point counter is pointing to the first body in the data array, every element following it is also a body up to data.Length-1
        while (counter != data.Length)
        {
            var body = new UDTO_Body();
            var segment = data[counter];
            var rest = segment.Split('!');
            body.decompress(rest);
            EstablishBody(body);
            counter++;
        }
        return counter;
    }

    public UDTO_Platform SetPositionTo(UDTO_Position loc)
    {
        position = loc;
        return this;
    }
    public UDTO_Body FindOrCreateBody(string name, bool create)
    {

        if (!_bodyLookup.TryGetValue(name, out UDTO_Body found) && create)
        {
            found = new UDTO_Body()
            {
                panID = panID,
                name = name,
                platformName = platformName,
                uniqueGuid = Guid.NewGuid().ToString()
            };
            _bodyLookup[name] = found;
        }
        return found;
    }

    public UDTO_Body EstablishBody(UDTO_Body body, bool delete = false)
    {
        if (_bodyLookup.TryGetValue(body.name, out UDTO_Body found))
        {
            found.type = body.type;

            if (found.position == null)
            {
                found.position = body.position;
            }
            else if (body.position != null)
            {
                found.position.copyFrom(body.position);
            }

            if (found.boundingBox == null)
            {
                found.boundingBox = body.boundingBox;
            }
            else if (body.boundingBox != null)
            {
                found.boundingBox.copyFrom(body.boundingBox);
            }

            if (delete)
            {
                _bodyLookup.Remove(body.name);
            }

        }
        else if (!delete)
        {
            _bodyLookup[body.name] = body;
            found = body;
        }
        return found;
    }

    public UDTO_Label FindOrCreateLabel(string name, bool create)
    {
        if (!_labelLookup.TryGetValue(name, out UDTO_Label found) && create)
        {
            found = new UDTO_Label()
            {
                panID = panID,
                name = name,
                platformName = platformName,
                uniqueGuid = Guid.NewGuid().ToString()
            };
            _labelLookup[name] = found;
        }
        return found;
    }

    public UDTO_Label EstablishLabel(UDTO_Label label, bool delete = false)
    {
        if (_labelLookup.TryGetValue(label.name, out UDTO_Label found))
        {
            found.type = label.type;
            found.text = label.text;

            if (found.position == null)
            {
                found.position = label.position;
            }
            else if (label.position != null)
            {
                found.position.copyFrom(label.position);
            }

            if (delete)
            {
                _labelLookup.Remove(label.name);
            }

        }
        else if (!delete)
        {
            _labelLookup[label.name] = label;
            found = label;
        }
        return found;
    }


}

