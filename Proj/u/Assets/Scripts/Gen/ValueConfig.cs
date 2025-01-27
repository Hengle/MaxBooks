// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gen/xls2proto/ValueConfig.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace X.Res {

  /// <summary>Holder for reflection information generated from gen/xls2proto/ValueConfig.proto</summary>
  public static partial class ValueConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for gen/xls2proto/ValueConfig.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ValueConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch9nZW4veGxzMnByb3RvL1ZhbHVlQ29uZmlnLnByb3RvEgVYLlJlcyI1CgtW",
            "YWx1ZUNvbmZpZxIRCglyYXRpbmdfaWQYASABKA0SEwoLcmF0aW5nX25hbWUY",
            "AiABKAkiNgoRVmFsdWVDb25maWdfQVJSQVkSIQoFaXRlbXMYASADKAsyEi5Y",
            "LlJlcy5WYWx1ZUNvbmZpZ2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::X.Res.ValueConfig), global::X.Res.ValueConfig.Parser, new[]{ "RatingId", "RatingName" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::X.Res.ValueConfig_ARRAY), global::X.Res.ValueConfig_ARRAY.Parser, new[]{ "Items" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ValueConfig : pb::IMessage<ValueConfig> {
    private static readonly pb::MessageParser<ValueConfig> _parser = new pb::MessageParser<ValueConfig>(() => new ValueConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ValueConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::X.Res.ValueConfigReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueConfig(ValueConfig other) : this() {
      ratingId_ = other.ratingId_;
      ratingName_ = other.ratingName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueConfig Clone() {
      return new ValueConfig(this);
    }

    /// <summary>Field number for the "rating_id" field.</summary>
    public const int RatingIdFieldNumber = 1;
    private uint ratingId_;
    /// <summary>
    ///* ��������ID 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint RatingId {
      get { return ratingId_; }
      set {
        ratingId_ = value;
      }
    }

    /// <summary>Field number for the "rating_name" field.</summary>
    public const int RatingNameFieldNumber = 2;
    private string ratingName_ = "";
    /// <summary>
    ///* �������� 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string RatingName {
      get { return ratingName_; }
      set {
        ratingName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ValueConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ValueConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RatingId != other.RatingId) return false;
      if (RatingName != other.RatingName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RatingId != 0) hash ^= RatingId.GetHashCode();
      if (RatingName.Length != 0) hash ^= RatingName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (RatingId != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(RatingId);
      }
      if (RatingName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(RatingName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RatingId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(RatingId);
      }
      if (RatingName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RatingName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ValueConfig other) {
      if (other == null) {
        return;
      }
      if (other.RatingId != 0) {
        RatingId = other.RatingId;
      }
      if (other.RatingName.Length != 0) {
        RatingName = other.RatingName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RatingId = input.ReadUInt32();
            break;
          }
          case 18: {
            RatingName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ValueConfig_ARRAY : pb::IMessage<ValueConfig_ARRAY> {
    private static readonly pb::MessageParser<ValueConfig_ARRAY> _parser = new pb::MessageParser<ValueConfig_ARRAY>(() => new ValueConfig_ARRAY());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ValueConfig_ARRAY> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::X.Res.ValueConfigReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueConfig_ARRAY() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueConfig_ARRAY(ValueConfig_ARRAY other) : this() {
      items_ = other.items_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueConfig_ARRAY Clone() {
      return new ValueConfig_ARRAY(this);
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::X.Res.ValueConfig> _repeated_items_codec
        = pb::FieldCodec.ForMessage(10, global::X.Res.ValueConfig.Parser);
    private readonly pbc::RepeatedField<global::X.Res.ValueConfig> items_ = new pbc::RepeatedField<global::X.Res.ValueConfig>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::X.Res.ValueConfig> Items {
      get { return items_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ValueConfig_ARRAY);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ValueConfig_ARRAY other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!items_.Equals(other.items_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= items_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      items_.WriteTo(output, _repeated_items_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += items_.CalculateSize(_repeated_items_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ValueConfig_ARRAY other) {
      if (other == null) {
        return;
      }
      items_.Add(other.items_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            items_.AddEntriesFrom(input, _repeated_items_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
