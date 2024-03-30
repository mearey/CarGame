#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Single UnityEngine.WheelHit::get_forwardSlip()
extern void WheelHit_get_forwardSlip_m1BA6AA2379368EFE2200B92AB4CA20F1AD537CCE (void);
// 0x00000002 System.Single UnityEngine.WheelHit::get_sidewaysSlip()
extern void WheelHit_get_sidewaysSlip_m7E27E0B36C1CC096C56B8815B7C1E7D380D6627B (void);
// 0x00000003 UnityEngine.WheelFrictionCurve UnityEngine.WheelCollider::get_sidewaysFriction()
extern void WheelCollider_get_sidewaysFriction_m7924ABBBB268B7F1FD8630733B6375CAFC2621E8 (void);
// 0x00000004 System.Void UnityEngine.WheelCollider::set_sidewaysFriction(UnityEngine.WheelFrictionCurve)
extern void WheelCollider_set_sidewaysFriction_mB2062696F29B4275C7F5B2874FD333ECD2325DA8 (void);
// 0x00000005 System.Void UnityEngine.WheelCollider::set_motorTorque(System.Single)
extern void WheelCollider_set_motorTorque_m4958AAF7D867CF7570420F9BAFAF04DC904F02A8 (void);
// 0x00000006 System.Void UnityEngine.WheelCollider::set_brakeTorque(System.Single)
extern void WheelCollider_set_brakeTorque_mB9B216C57C275470907C7DB35185E2F192DC8DAB (void);
// 0x00000007 System.Void UnityEngine.WheelCollider::set_steerAngle(System.Single)
extern void WheelCollider_set_steerAngle_m7BF83B27D8956355F873537939BE9F35CF3113C3 (void);
// 0x00000008 System.Boolean UnityEngine.WheelCollider::GetGroundHit(UnityEngine.WheelHit&)
extern void WheelCollider_GetGroundHit_mCB73878577BC5AAEBEA8572FA62326C4C71B3EF2 (void);
// 0x00000009 System.Void UnityEngine.WheelCollider::get_sidewaysFriction_Injected(UnityEngine.WheelFrictionCurve&)
extern void WheelCollider_get_sidewaysFriction_Injected_m18A6CB2191D1CE62B131E11BFB5308F8A9C6FCD1 (void);
// 0x0000000A System.Void UnityEngine.WheelCollider::set_sidewaysFriction_Injected(UnityEngine.WheelFrictionCurve&)
extern void WheelCollider_set_sidewaysFriction_Injected_mFE019F748A809846714267E3AA9DB8C49616A1A9 (void);
static Il2CppMethodPointer s_methodPointers[10] = 
{
	WheelHit_get_forwardSlip_m1BA6AA2379368EFE2200B92AB4CA20F1AD537CCE,
	WheelHit_get_sidewaysSlip_m7E27E0B36C1CC096C56B8815B7C1E7D380D6627B,
	WheelCollider_get_sidewaysFriction_m7924ABBBB268B7F1FD8630733B6375CAFC2621E8,
	WheelCollider_set_sidewaysFriction_mB2062696F29B4275C7F5B2874FD333ECD2325DA8,
	WheelCollider_set_motorTorque_m4958AAF7D867CF7570420F9BAFAF04DC904F02A8,
	WheelCollider_set_brakeTorque_mB9B216C57C275470907C7DB35185E2F192DC8DAB,
	WheelCollider_set_steerAngle_m7BF83B27D8956355F873537939BE9F35CF3113C3,
	WheelCollider_GetGroundHit_mCB73878577BC5AAEBEA8572FA62326C4C71B3EF2,
	WheelCollider_get_sidewaysFriction_Injected_m18A6CB2191D1CE62B131E11BFB5308F8A9C6FCD1,
	WheelCollider_set_sidewaysFriction_Injected_mFE019F748A809846714267E3AA9DB8C49616A1A9,
};
extern void WheelHit_get_forwardSlip_m1BA6AA2379368EFE2200B92AB4CA20F1AD537CCE_AdjustorThunk (void);
extern void WheelHit_get_sidewaysSlip_m7E27E0B36C1CC096C56B8815B7C1E7D380D6627B_AdjustorThunk (void);
static Il2CppTokenAdjustorThunkPair s_adjustorThunks[2] = 
{
	{ 0x06000001, WheelHit_get_forwardSlip_m1BA6AA2379368EFE2200B92AB4CA20F1AD537CCE_AdjustorThunk },
	{ 0x06000002, WheelHit_get_sidewaysSlip_m7E27E0B36C1CC096C56B8815B7C1E7D380D6627B_AdjustorThunk },
};
static const int32_t s_InvokerIndices[10] = 
{
	3870,
	3870,
	3930,
	3289,
	3237,
	3237,
	3237,
	2197,
	3118,
	3118,
};
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_UnityEngine_VehiclesModule_CodeGenModule;
const Il2CppCodeGenModule g_UnityEngine_VehiclesModule_CodeGenModule = 
{
	"UnityEngine.VehiclesModule.dll",
	10,
	s_methodPointers,
	2,
	s_adjustorThunks,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
