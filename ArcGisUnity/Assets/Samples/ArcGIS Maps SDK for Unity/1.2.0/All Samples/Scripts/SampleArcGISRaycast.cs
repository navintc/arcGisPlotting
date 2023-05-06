// Copyright 2022 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
using Esri.ArcGISMapsSDK.Components;
using Esri.Unity;
using Esri.GameEngine.Layers;
using Esri.GameEngine.Geometry;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

using System;
using System.Runtime.InteropServices;

public class SampleArcGISRaycast : MonoBehaviour
{
	public ArcGISMapComponent arcGISMapComponent;
	public ArcGISCameraComponent arcGISCamera;
	public Canvas canvas;
	public Text featureText;
	public Text metadataText;
	public enum AttributeType
	{
		None,
		ConstructionYear,
		BuildingName
	};

	[SerializeField]
	private AttributeType layerAttribute = AttributeType.None;

	private AttributeType lastLayerAttribute;
	private Esri.GameEngine.Attributes.ArcGISAttributeProcessor attributeProcessor;

    private void OnEnable()
	{
#if ENABLE_INPUT_SYSTEM
		Debug.Log("ArcGISRaycast sample is not configured to work with the new input manager package");
		enabled = false;
#endif
	}

    void Start()
    {

	}

    void Update()
    {
#if !ENABLE_INPUT_SYSTEM
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				var arcGISRaycastHit = arcGISMapComponent.GetArcGISRaycastHit(hit);
				var layer = arcGISRaycastHit.layer;
				var featureId = arcGISRaycastHit.featureId;
				

				DumpToConsole(arcGISRaycastHit.layer);
				DumpToConsole(arcGISRaycastHit);

				if (layer != null && featureId != -1)
				{
					featureText.text = featureId.ToString();
					metadataText.text = JSONReader.getCity(featureId.ToString());
					//metadataText.text = "testick test test testo testico";

					var geoPosition = arcGISMapComponent.EngineToGeographic(hit.point);
					var offsetPosition = new ArcGISPoint(geoPosition.X, geoPosition.Y, geoPosition.Z + 200, geoPosition.SpatialReference);

					var rotation = arcGISCamera.GetComponent<ArcGISLocationComponent>().Rotation;
					var location = canvas.GetComponent<ArcGISLocationComponent>();
					location.Position = offsetPosition;
					location.Rotation = rotation;
				}
			}
		}
#endif
	}
	public static void DumpToConsole(object obj)
	{
		var output = JsonUtility.ToJson(obj, true);
		Debug.Log(output);
	}

	private void Setup3DAttributesFloatAndIntegerType(Esri.GameEngine.Layers.ArcGIS3DObjectSceneLayer layer)
	{
		// We want to set up an array with the attributes we want to forward to the material
		// Because CNSTRCT_YR is an esriFieldTypeInteger type, the values can be passed directly to the material as an integer
		// esriFieldTypeSingle, esriFieldTypeSmallInteger, esriFieldTypeInteger and esriFieldTypeDouble can be passed directly to the material without processing
		// esriFieldTypeDouble and esriFieldTypeSingle are converted to a float, resulting in a lossy conversion
		// See Setup3DAttributesOtherType below for an example of how to pass non-numeric types to the material
		var layerAttributes = ArcGISImmutableArray<String>.CreateBuilder();
		layerAttributes.Add("CNSTRCT_YR");
		layer.SetAttributesToVisualize(layerAttributes.MoveToArray());

		// We want to set the material we will use to visualize this layer
		// In Unity, open this material in the Shader Graph to view its implementation
		// In general, you can use this function in other scripts to change the material that is used to render the buildings
		layer.MaterialReference = new Material(Resources.Load<Material>("Materials/" + DetectRenderPipeline() + "/ConstructionYearRenderer"));
	}

	// This function detects the rendering pipeline used by the project to choose from the pre-defined materials made for HDRP or URP
	private string DetectRenderPipeline()
	{
		if (GraphicsSettings.renderPipelineAsset != null)
		{
			var renderType = GraphicsSettings.renderPipelineAsset.GetType().ToString();

			if (renderType == "UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset")
			{
				return "URP";
			}
			else if (renderType == "UnityEngine.Rendering.HighDefinition.HDRenderPipelineAsset")
			{
				return "HDRP";
			}
		}

		return "Legacy";
	}

}
