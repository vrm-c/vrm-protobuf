# DEPRECATED
This repository was trial implementation of vrm-1.0.
Go to https://github.com/vrm-c/UniVRM

---


# vrm-protobuf

このリポジトリは、 [UniVRM-1.0](https://github.com/vrm-c/UniVRM_1_0) 向けの `proto` ファイルを管理しています。

`proto` ファイルは、[glTF](https://github.com/KhronosGroup/glTF) と [vrm-specification](https://github.com/vrm-c/vrm-specification) の `JSON Schema` から
生成します。

## VrmJsonScheme

### GenerateProto
`UniVRM-1.0` のシリアライザ向けの変換器です。
`glTF-2.0` と `vrm-1.0` の JsonScheme をパースして、 `proto` ファイルを生成します。

### GenerateValidator

`.vscode/launch.json` の `GenerateProto` で生成する。

### VrmValidator

VrmのJson部分をValidateする

## TODO

* [x] (GLTF)extensionの接続
* [x] (GLTF)(定数)check unknown properties
* [x] (GLTF)(定数)glTFid に対する下限チェック
* [ ] (GLTF)(定数)enum に対するチェック
* [ ] (GLTF)(Runtime)glTFid に対する上限チェック
* [ ] (GLTF)(Runtime)bufferに対する範囲チェック
* [ ] (GLTF)(Runtime)未使用Mesh
* [ ] (GLTF)(Runtime)未使用Material
* [ ] (GLTF)(Runtime)未使用Image
* [ ] (GLTF)(Runtime)未使用BufferView
* [ ] (GLTF)(Runtime)未使用Buffer範囲
* [ ] (VRM)(定数)isNormalized
* [ ] (VRM0x)(定数)hasHumanoidBones
* [ ] (VRM0x)(定数)validMeta
* [ ] (VRM0x)(定数)unknown shader
* [ ] (VRM0x)(Runtime)頂点カラーを使わないのに持っているタイプ(特にunlit)
* [ ] (VRM0x)(Runtime)未使用BlendShape
* [ ] (VRM10)(定数)hasHumanoidBones
* [ ] (VRM10)(定数)validMeta
