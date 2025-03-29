using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;

public class DateOnlySerializer : SerializerBase<DateOnly>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateOnly value)
    {
        context.Writer.WriteString(value.ToString("yyyy-MM-dd"));
    }

    public override DateOnly Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var dateAsString = context.Reader.ReadString();
        if (DateOnly.TryParse(dateAsString, out DateOnly date))
        {
            return date;
        }
        else
        {
            throw new FormatException($"Invalid date format: {dateAsString}");
        }
    }
}
