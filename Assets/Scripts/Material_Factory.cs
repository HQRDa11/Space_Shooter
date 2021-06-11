using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Factory
{
    public Material[] rarityMaterials = new Material[(int)(Rarity.Total)];
    public Material[] statusMaterials = new Material[(int)(Status.Total)];

    public Material_Factory()
    {
                // Materials 
                rarityMaterials[0] = new Material(Resources.Load<Material>("Materials/Rarity/Grey"));
                rarityMaterials[1] = new Material(Resources.Load<Material>("Materials/Rarity/White"));
                rarityMaterials[2] = new Material(Resources.Load<Material>("Materials/Rarity/Green"));
                rarityMaterials[3] = new Material(Resources.Load<Material>("Materials/Rarity/Blue"));
                rarityMaterials[4] = new Material(Resources.Load<Material>("Materials/Rarity/Purple"));
                rarityMaterials[5] = new Material(Resources.Load<Material>("Materials/Rarity/Orange"));
                
                // Status
                statusMaterials[0] = new Material(Resources.Load<Material>("Materials/Status/Black"));
                statusMaterials[1] = new Material(Resources.Load<Material>("Materials/Status/Red"));
                statusMaterials[2] = new Material(Resources.Load<Material>("Materials/Status/Green"));
                statusMaterials[3] = new Material(Resources.Load<Material>("Materials/Status/White"));


    }

    public Material GetMaterial(Rarity color)
    {
        return rarityMaterials[(int)color];
    }
    public Material GetMaterial(Status color)
    {
        return rarityMaterials[(int)color];
    }

}
