﻿using UnityEditor;
using UnityEngine;

namespace HQRDa
{

    namespace NQSH
    {
        public class TODOList
        {
            // DONE - Add Combo loss overtime

            // DONE - Create Library
            // DONE - Add new class for CheckPointsList in Library
            // DONE - Add new class for WaveList in Library
            // DONE - Add new class for EnemyList in Library
            // DONE - Add The Worm wave to Library

            // DONE - Create new class for Basic Enemy
            // DONE - Create new class for Boss (Head & Body)
            // DONE - Enemy Factory Refont            

            // DONE - Enemy HealthBar appear when isn't full HP

            // DONE - Add Tool to translate direction in rotation
            // DONE - Add Tool to translate rotation in direction

            // >TODO - Add Spawn area VisualAlert
            // >TODO - Add ShotLoading effect in General Factory
            // >TODO - Add Combo loss when touch by enemy's hitbox <<< For some enemies only
            // >TODO - Creer une zone plus large pour la destrcution des projectiles > Sinn quand l'ennemi est en dehors de l'ecran
            //      les projectiles sont detruits directement
            // >TODO - Ajouter effet d'impact quand touché > Creer un gameObject en Child avec meme apparence(Sprite), teinte Rouge, Opacité reduite, puis le détruire 0.1 seconde apres;
            // >TODO - Enemy shot with Frencency balancing

            // >TODO - Change background sprite (To Vectorized)

            // ===============
            // =   ENEMIES   =
            // ===============

            // --- Basic ---

            // DONE - Add Enemy with normal single shot, following the wave's checkpoints list.
            // DONE - Add Enemy with circle shot, picking a random checkpoint to move around.
            // DONE - Add Enemy with spiral shot, picking a random checkpoint to move around.
            // DONE - Add Enemy Sniper
            // 
            // >TODO - Add Enemy ShotGun
            // >TODO - Ennemi qui garde un checkpoint fixe mais bouger aleatoirement autour de celui ci. Vise constamment le joueur et tire a une frequence a definir.

            // --- Boss ---

            // DONE - Add Boss > The Worm

            // >TODO - Add Enemy TheCrab

            // ================
            // =  BEHAVIOURS  =
            // ================

            // DONE - Add MoveBehaviour > Random movement around checkpoint
            // DONE - Add DeathHebaviour for The Worm(Head) > Stop all body parts moves and set them OnHeadDeath
            // DONE - Add DeathBehaviour for The Worm(Body) > Shoot OnDestruction
            // DONE - Add Weapon Behaviour = Load shot when he's arrived on his checkPoint and keep Player's position ATM,
            //      then shoot in the direction when shot is load. Then Unfreeze Movement.
            // DONE - Add Movement Behaviour = Move to checkPoints choosen when the last is reached. Shoot() when he's is at radius range and Freeze when he's on the point.

            // Rajouter pattern de tir sur TheWorm quand midLife, tir circle toutes les 5 sec pour ex. avec autant de projectiles que de parties de corps.
            // Gagne des effets de projectiles avec des modules de tourelle de haut niveau
            // IDEE module de tire secondaire gros rayon avec grand temps de reload
            // BOSS Un pour chaque type de Basic enemy dans la mesure du possible
            // BOSS IDEE + Pour le 2e, tir avec les 6 pattes (J'me comprends)
            
        }
    }

    public class TODOList
    {
        //TO DO:
        // ok - Shield Bonus
        // ok - Shield Mechanics
        // ok - Add satisfying compponent loot display in EndGameScreen
        // ok - Creates a default SquadronData class CTOR returning simplest SquadronData for new prodiles.
        // ok - Creates Profile Handler.cs: Profile NewProfile()
        // ok - Create Profile.ResetProfile();
        // ok - Profile Handler.cs: Profile NewProfile() : is launched if no valid latest save
        // ok - SquadronData is now save in profile correctly;
        // ok - Update : UI_Update.cs
        //      ok - Button : back to mainMenu
        //      ok - Button template : switch states(previous/next)
        //          ok - Next/Previous States Mechanics
        //      ok - Fonctionnal Squadron Display 
        //      ok - Functionnal Member Display
        //      ok - Functionnal Module Display
        // ok - Tools new fctn: int NewIndex( bool isNext_ifNotPrevious, int currentIndex) 
        // ok - ModuleData.cs:
        //      ok - Add [m_tier: int]
        //      ok - Add fnctn Sprite GetSprite()
        // ok - Create a Module_Factory class
        //      ok - RandomModule() : ModuleData 
        // ok - Factory.cs :
        //      ok - Dice_BonusTier(int tier) :  int 
        //      ok - m_moduleFactory : Module_Factory
        // ok - Creates FinalLoot.cs:
        //      ok - m_options : ModuleData[3]
        // - EndGame_ApplicationState:
        //      ok - m_finalLoot : FinalLoot
        //      ok - Chest FinalLoot based on Score : "pick 1 option out of 3" style
        //          ok - FinalLoot_HiddenDisplay(); 
        //          ok - FinalLoot_DiscoveredDisplay();
        //          ok - FinalLoot_Open(int selection);
        // ok - UI_Endgame.cs & prefab :
        //      ok - Display_FinalLoot.prefab
        //          ok - Button_LootOption.prefab
        //      ok - Link buttons to UI_EnGame class fields
        // ok - component stats mechanics
        //      ok - Create stats panel Prefab.
        //      ok - class ModuleStat
        //      ok - class ModuleStats_Factory: 
        //      ok - GetStats(Module module) : ModuleStat[]
        // ok - ScrollPanel.prefab
        // ok - UI_Upgrade.cs : Module upgrade
        //      ok - to do: Panel m_moduleStats_Display;
        //      ok - to do: Sprite m_moduleSprite;
        //
        // ok - Deposit.cs:
        //      - High damage on collision
        //      - MiningDrones
        //      later - Mining should be more rewarding than shooting it.
        //      
        //  ok - supprimer moduleStat_Factory et mettre les methode type de retour de stat respectivement dans module_factory et ship_factory ( bien plus intelligent et pratique )
        //
        // ok - Rarety dice : 1/4 chance of looting higher rarity
        //
        // - UI_Upgrade.cs : Ship upgrade
        //      - Triple upgrade cost
        //      ok - Panel m_shipStats_Display; 
        //      delayed (need sprites) : Sprite m_shipSprite;
        // - construct Ship GameObject with ShipData object on game start
        // - Null module type:
        //      - m_name: string "no module";
        //      - m_sprite : Sprite ("Resources.load/Sprites/noModule")
        //
        // - ShipData & ModuleData new update mechanics: spend components to add xp to LevelData
        //
        // - UI_Game.cs : image + Text pop-Up On bonus pickup
        // - Recharge on shield and drones (is used when pickip up a drone and no drone slot free, converted to energy);.
        // - Create a Reset Profile button in MainMenu
        // - Update gameInfo with last achieved wave number. => determine finalLoot value? with score too?
        // delayed - Factory.cs:  Dice_FinalLoot() : FinalLoot (delay : FinalLootObject not complex enough)
        // - Creates bonus rarity for shields and repairDrones bonuses
        // - Remove all _lifeTime updates from Bonuses and replace with Map.IsOnScreen check (as done in repairbonus.cs)
        // - dans UI_EndGame. cs possible de caluler et afficher une mention a partir des loot et du score? (: viur 'NOTE1' dans UI_EndGame.cs)
    }

    public class GameStories
    {
        // CAMPAGNE

        // Chapitre 1 - Le terrain d'entrainement
        // - Nous sommes envoyés dans cette zone quasi déserte ou quelques NormalShot trainent encore de temps à autres.
        // - Notre seule mission est de s'amuser avec notre nouveau Joujou, histoire de se faire la main.

        // - Nous sommes prévenus qu'un ver de l'espace a été aperçu non loin du terrain, et demandés en aide d'urgence.
        // - On déconne pas avec ces bêtes la !
    }
}

