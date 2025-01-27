// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gen/xls2proto/FuncParamConfig.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace X.Res {

  /// <summary>Holder for reflection information generated from gen/xls2proto/FuncParamConfig.proto</summary>
  public static partial class FuncParamConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for gen/xls2proto/FuncParamConfig.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static FuncParamConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiNnZW4veGxzMnByb3RvL0Z1bmNQYXJhbUNvbmZpZy5wcm90bxIFWC5SZXMi",
            "VQoPRnVuY1BhcmFtQ29uZmlnEg8KB2Z1bmNfaWQYASABKA0SDwoHcGFyYW1z",
            "MRgCIAMoBRIPCgdwYXJhbXMyGAMgAygFEg8KB3BhcmFtczMYBCADKAUiPgoV",
            "RnVuY1BhcmFtQ29uZmlnX0FSUkFZEiUKBWl0ZW1zGAEgAygLMhYuWC5SZXMu",
            "RnVuY1BhcmFtQ29uZmlnYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::X.Res.FuncParamConfig), global::X.Res.FuncParamConfig.Parser, new[]{ "FuncId", "Params1", "Params2", "Params3" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::X.Res.FuncParamConfig_ARRAY), global::X.Res.FuncParamConfig_ARRAY.Parser, new[]{ "Items" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class FuncParamConfig : pb::IMessage<FuncParamConfig> {
    private static readonly pb::MessageParser<FuncParamConfig> _parser = new pb::MessageParser<FuncParamConfig>(() => new FuncParamConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FuncParamConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::X.Res.FuncParamConfigReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FuncParamConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FuncParamConfig(FuncParamConfig other) : this() {
      funcId_ = other.funcId_;
      params1_ = other.params1_.Clone();
      params2_ = other.params2_.Clone();
      params3_ = other.params3_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FuncParamConfig Clone() {
      return new FuncParamConfig(this);
    }

    /// <summary>Field number for the "func_id" field.</summary>
    public const int FuncIdFieldNumber = 1;
    private uint funcId_;
    /// <summary>
    ///* 功能参数id 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint FuncId {
      get { return funcId_; }
      set {
        funcId_ = value;
      }
    }

    /// <summary>Field number for the "params1" field.</summary>
    public const int Params1FieldNumber = 2;
    private static readonly pb::FieldCodec<int> _repeated_params1_codec
        = pb::FieldCodec.ForInt32(18);
    private readonly pbc::RepeatedField<int> params1_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///* 参数数组1 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> Params1 {
      get { return params1_; }
    }

    /// <summary>Field number for the "params2" field.</summary>
    public const int Params2FieldNumber = 3;
    private static readonly pb::FieldCodec<int> _repeated_params2_codec
        = pb::FieldCodec.ForInt32(26);
    private readonly pbc::RepeatedField<int> params2_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///* 参数数组2 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> Params2 {
      get { return params2_; }
    }

    /// <summary>Field number for the "params3" field.</summary>
    public const int Params3FieldNumber = 4;
    private static readonly pb::FieldCodec<int> _repeated_params3_codec
        = pb::FieldCodec.ForInt32(34);
    private readonly pbc::RepeatedField<int> params3_ = new pbc::RepeatedField<int>();
    /// <summary>
    ///* 参数数组3 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<int> Params3 {
      get { return params3_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FuncParamConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FuncParamConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FuncId != other.FuncId) return false;
      if(!params1_.Equals(other.params1_)) return false;
      if(!params2_.Equals(other.params2_)) return false;
      if(!params3_.Equals(other.params3_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (FuncId != 0) hash ^= FuncId.GetHashCode();
      hash ^= params1_.GetHashCode();
      hash ^= params2_.GetHashCode();
      hash ^= params3_.GetHashCode();
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
      if (FuncId != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(FuncId);
      }
      params1_.WriteTo(output, _repeated_params1_codec);
      params2_.WriteTo(output, _repeated_params2_codec);
      params3_.WriteTo(output, _repeated_params3_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (FuncId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(FuncId);
      }
      size += params1_.CalculateSize(_repeated_params1_codec);
      size += params2_.CalculateSize(_repeated_params2_codec);
      size += params3_.CalculateSize(_repeated_params3_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FuncParamConfig other) {
      if (other == null) {
        return;
      }
      if (other.FuncId != 0) {
        FuncId = other.FuncId;
      }
      params1_.Add(other.params1_);
      params2_.Add(other.params2_);
      params3_.Add(other.params3_);
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
            FuncId = input.ReadUInt32();
            break;
          }
          case 18:
          case 16: {
            params1_.AddEntriesFrom(input, _repeated_params1_codec);
            break;
          }
          case 26:
          case 24: {
            params2_.AddEntriesFrom(input, _repeated_params2_codec);
            break;
          }
          case 34:
          case 32: {
            params3_.AddEntriesFrom(input, _repeated_params3_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class FuncParamConfig_ARRAY : pb::IMessage<FuncParamConfig_ARRAY> {
    private static readonly pb::MessageParser<FuncParamConfig_ARRAY> _parser = new pb::MessageParser<FuncParamConfig_ARRAY>(() => new FuncParamConfig_ARRAY());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FuncParamConfig_ARRAY> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::X.Res.FuncParamConfigReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FuncParamConfig_ARRAY() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FuncParamConfig_ARRAY(FuncParamConfig_ARRAY other) : this() {
      items_ = other.items_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FuncParamConfig_ARRAY Clone() {
      return new FuncParamConfig_ARRAY(this);
    }

    /// <summary>Field number for the "items" field.</summary>
    public const int ItemsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::X.Res.FuncParamConfig> _repeated_items_codec
        = pb::FieldCodec.ForMessage(10, global::X.Res.FuncParamConfig.Parser);
    private readonly pbc::RepeatedField<global::X.Res.FuncParamConfig> items_ = new pbc::RepeatedField<global::X.Res.FuncParamConfig>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::X.Res.FuncParamConfig> Items {
      get { return items_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FuncParamConfig_ARRAY);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FuncParamConfig_ARRAY other) {
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
    public void MergeFrom(FuncParamConfig_ARRAY other) {
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
